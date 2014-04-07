using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace Backup
{
    public partial class SelectRecovery : Form
    {
        public SelectRecovery(Configuration configuration)
        {
            InitializeComponent();
            string directory = configuration.HistoryDirectory;
            treeViewFiles.Nodes.Add(SetDirectory(directory));
        }

        TreeNode SetDirectory(string directoryPath)
        {
            string[] parts = directoryPath.Split('\\');
            TreeNode newNode = new TreeNode(parts[parts.Count()-1]);

            string[] directories = Directory.GetDirectories(directoryPath);
            foreach (string directory in directories)
                newNode.Nodes.Add(SetDirectory(directory));

            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
                newNode.Nodes.Add(SetFileInfo(file));

            return newNode;
        }

        TreeNode SetFileInfo(string fileName)
        {
            FileHistory history;

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FileHistory));
                history = (FileHistory)serializer.Deserialize(streamReader);
                streamReader.Close();
            }

            TreeNode newNode = new TreeNode(Path.GetFileName(history.FilePath));
            foreach(Info info in history.BackupHistory)
            {
                TreeNode newInfoNode = new TreeNode(string.Format("{0}, size: {1}, flags: {2}, backup path: {3}",
                    info.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    info.Length,
                    info.Attributes,
                    info.BackupPath));

                newInfoNode.Tag = info;
                newNode.Nodes.Add(newInfoNode);
            }

            return newNode;
        }

        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            Info info = (Info)e.Node.Tag;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = e.Node.Parent.Text;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (File.Exists(dialog.FileName))
                File.Delete(dialog.FileName);

            File.Copy(info.BackupPath, dialog.FileName);
        }
    }
}
