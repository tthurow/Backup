using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.AccessControl;


namespace Backup
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }

    public class BackupJob
    {
        Configuration configuration;
        string targetPath;
        int savedFiles;
        DateTime startTime;
        DateTime endTime;
        StreamWriter logFile;
        int numberOfErrors;

        public int SavedFiles { get { return savedFiles; } }

        public int NumberOfErrors { get { return numberOfErrors; } }

        public DateTime StartTime { get { return startTime; } }

        public DateTime EndTime { get { return endTime; } }

        public int Start(Configuration configuration, string targetPath)
        {
            this.configuration = configuration;
            this.savedFiles = 0;
            this.startTime = DateTime.Now;

            DateTime dateTime = DateTime.Now;
            string directoryName = dateTime.ToString("MM-dd-yy H-mm-ss");
            logFile = new StreamWriter("Log_" + directoryName + ".txt");

//            this.targetPath = "\\\\?\\" + targetPath + '\\' + directoryName;
            this.targetPath = targetPath + '\\' + directoryName;

            DirectoryInfo directoryInfo = Directory.CreateDirectory(this.targetPath);
            foreach (string filePath in configuration.FileSources)
                CheckFile(filePath);

            foreach (string directoryPath in configuration.DirectorySources)
                CheckDirectory(directoryPath);

            this.endTime = DateTime.Now;

            logFile.Close();

            return savedFiles;
        }

        void CheckDirectory(string directoryPath)
        {
            try
            {
                string[] directories = Directory.GetDirectories(directoryPath);
                foreach (string directory in directories)
                    CheckDirectory(directory);
            }
            catch(Exception e)
            {
                logFile.WriteLine(string.Format("Error read directorys in {0}, exception {1}", directoryPath, e.ToString()));
                logFile.Flush();
                numberOfErrors++;
            }

            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                    CheckFile(file);
            }
            catch (Exception e)
            {
                logFile.WriteLine(string.Format("Error read files in {0}, exception {1}", directoryPath, e.ToString()));
                logFile.Flush();
                numberOfErrors++;
            }
        }

        void CheckFile(string sourceFileName)
        {
            if (configuration.FileExcludes.Contains(sourceFileName))
                return;

            FileInfo fileInfo = new FileInfo(sourceFileName);
            FileAttributes fileAttributes = fileInfo.Attributes;
            if (!fileAttributes.HasFlag(FileAttributes.Archive))
                return;

            char[] newFileName = sourceFileName.ToCharArray();
            if (newFileName[1] == ':')
                newFileName[1] = '$';

//            SHA1 sha1 = new SHA1CryptoServiceProvider();
//            sha1.ComputeHash(File.ReadAllBytes(sourceFileName));

            string targetFileName = targetPath + '\\' + new string(newFileName);
            CreateDirectories(targetFileName);
            CopyFile(sourceFileName, targetFileName);
            fileInfo.Attributes = fileInfo.Attributes ^ FileAttributes.Archive;

            string historyFileName = configuration.HistoryDirectory + '\\' + new string(newFileName) + ".history";
            CreateDirectories(historyFileName);
            SetHistoryFile(historyFileName, fileInfo, targetFileName);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool CreateDirectoryW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpPathName,
            SECURITY_ATTRIBUTES lpSecurityAttributes);

        void CreateDirectories(string targetFileName)
        {
            string[] directories = targetFileName.Split('\\');
            string fullPath = directories[0];
            for (int index = 1; index < directories.Count(); index++)
            {
                if (!Directory.Exists(fullPath))
                {
                    /*
                    DirectorySecurity security = new DirectorySecurity();
                    byte[] src = security.GetSecurityDescriptorBinaryForm();
                    IntPtr dest = Marshal.AllocHGlobal(src.Length);
                    Marshal.Copy(src, 0, dest, src.Length);
                    
                    SECURITY_ATTRIBUTES lpSecurityAttributes = new SECURITY_ATTRIBUTES();
                    lpSecurityAttributes.nLength = Marshal.SizeOf(lpSecurityAttributes);
                    lpSecurityAttributes.lpSecurityDescriptor = dest;

                    CreateDirectoryW("\\\\?\\" + fullPath, null);*/

                    Directory.CreateDirectory(fullPath);
                }

                fullPath += '\\' + directories[index];
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool CopyFileW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpExistingFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpNewFileName,
            bool bFailIfExists);

        void CopyFile(string sourceFileName, string targetFileName)
        {
            CopyFileW("\\\\?\\" + sourceFileName, "\\\\?\\" + targetFileName, false);
            //File.Copy(sourceFileName, targetFileName);
            savedFiles++;
        }

        void SetHistoryFile(string fileName, FileInfo fileInfo, string targetFileName)
        {
            FileHistory history;

            if (File.Exists(fileName))
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FileHistory));
                    history = (FileHistory)serializer.Deserialize(streamReader);
                    streamReader.Close();
                }
            }
            else
                history = new FileHistory(fileInfo.FullName);

            history.BackupHistory.Add(new Info(fileInfo, targetFileName));

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FileHistory));
                serializer.Serialize(streamWriter, history);
                streamWriter.Close();
            }
        }

        public static void ResetDirectory(string directoryPath)
        {
            try
            {
                string[] directories = Directory.GetDirectories(directoryPath);
                foreach (string directory in directories)
                    ResetDirectory(directory);

                string[] files = Directory.GetFiles(directoryPath);
                ResetFiles(files);
            }
            catch(System.UnauthorizedAccessException e)
            {
                int a = 3;
            }
        }

        public static void ResetFiles(string[] files)
        {
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                FileAttributes fileAttributes = fileInfo.Attributes;
                if (fileAttributes.HasFlag(FileAttributes.Archive))
                    return;

                fileInfo.Attributes = fileInfo.Attributes ^ FileAttributes.Archive;
            }
        }
    }
}
