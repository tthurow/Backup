using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Backup
{
    [Serializable]
    public class Info
    {
        public FileAttributes Attributes;
        public DateTime CreationTime;
        public DateTime LastAccessTime;
        public DateTime LastWriteTime;
        public long Length;
        public bool IsReadOnly;
        public string BackupPath;
        
        public Info(FileInfo fileInfo, string backupPath)
        {
            this.Attributes = fileInfo.Attributes;
            this.CreationTime = fileInfo.CreationTime;
            this.LastAccessTime = fileInfo.LastAccessTime;
            this.LastWriteTime = fileInfo.LastWriteTime;
            this.Length = fileInfo.Length;
            this.IsReadOnly = fileInfo.IsReadOnly;
            this.BackupPath = backupPath;
        }

        public Info()
        {}
    }

    [Serializable]
    public class FileHistory
    {
        public string FilePath = "";
        public List<Info> BackupHistory = new List<Info>();

        public FileHistory(string filePath)
        {
            FilePath = filePath;
        }

        public FileHistory()
        { }
    }
}
