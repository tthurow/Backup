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
    public partial class MainForm : Form
    {
        Configuration configuration = new Configuration();
        bool modifyed = false;

        public MainForm()
        {
            InitializeComponent();
            configuration.HistoryDirectory = "c:\\History";
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            if (modifyed)
            {
                if (MessageBox.Show(
                    "Achtung, die aktuelle Konfiguration wurde geändert, aber noch nicht gespeichert. Wollen Sie wirklich eine neue Konfiguration laden?",
                    "Warnung",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error) == DialogResult.Cancel)
                    return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Backup configuration (*.bcf)|*.bcf|All files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            StreamReader streamReader = new StreamReader(dialog.FileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            configuration = (Configuration)serializer.Deserialize(streamReader);

            dataGridView.Rows.Clear();
            foreach(string directory in configuration.DirectorySources)
            {
                dataGridView.Rows.Add(directory);
            }

            foreach (string file in configuration.FileSources)
            {
                dataGridView.Rows.Add(file);
            }

            comboBoxTarget.Items.Clear();
            foreach (string target in configuration.Targets)
                comboBoxTarget.Items.Add(target);

            comboBoxTarget.Text = "";
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Backup configuration (*.bcf)|*.bcf|All files (*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            StreamWriter streamWriter = new StreamWriter(dialog.FileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            serializer.Serialize(streamWriter, configuration);
            streamWriter.Close();

            modifyed = false;
        }        
        
        private void buttonStartBackup_Click(object sender, EventArgs e)
        {
            BackupJob job = new BackupJob();
            string targetDirectory = comboBoxTarget.Text;
            if (!configuration.Targets.Contains(targetDirectory))
            {
                configuration.Targets.Add(targetDirectory);
                modifyed = true;
            }

            int files = job.Start(configuration, targetDirectory);

            MessageBox.Show(string.Format("Backup abgeschlossen, {0} Dateien in {1} Sekunden, {2} Fehler", 
                files, 
                (job.EndTime - job.StartTime).TotalSeconds, 
                job.NumberOfErrors));
        }

        private void buttonRecoveryFile_Click(object sender, EventArgs e)
        {
            SelectRecovery dialog = new SelectRecovery(configuration);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
        }

        private void toolStripMenuItemNewSourceDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string directory = dialog.SelectedPath;
            if (configuration.DirectorySources.Contains(directory))
            {
                MessageBox.Show(
                    string.Format("Achtung, Verzeichnis {0} ist bereits in der Liste, wird daher ignoriert", directory),
                    "Eingabefehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            configuration.DirectorySources.Add(directory);
            modifyed = true;

            dataGridView.Rows.Add(directory);
        }

        private void toolStripMenuItemNewSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string[] files = dialog.FileNames;
            foreach (string file in files)
            {
                if (configuration.FileSources.Contains(file))
                {
                    MessageBox.Show(
                        string.Format("Achtung, Datei {0} ist bereits in der Liste, wird daher ignoriert", file),
                        "Eingabefehler",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                configuration.FileSources.Add(file);
                modifyed = true;

                dataGridView.Rows.Add(file);
            }
        }

        private void toolStripMenuItemErase_Click(object sender, EventArgs e)
        {
            int a = 3;
        }

        private void toolStripMenuItemEraseCell_Click(object sender, EventArgs e)
        {
            int a = 3;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifyed)
            {
                if (MessageBox.Show(
                    "Achtung, die aktuelle Konfiguration wurde geändert, aber noch nicht gespeichert. Wollen Sie wirklich die Anwendung schließen?",
                    "Warnung",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error) == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void buttonResetDirectorys_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string directory = dialog.SelectedPath;
            BackupJob.ResetDirectory(directory);
        }
    }
}
