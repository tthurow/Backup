namespace Backup
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripErase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEraseCell = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripSources = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewSourceDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewSourceFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemErase = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.buttonStartBackup = new System.Windows.Forms.Button();
            this.buttonRecoveryFile = new System.Windows.Forms.Button();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.comboBoxTarget = new System.Windows.Forms.ComboBox();
            this.buttonResetDirectorys = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStripErase.SuspendLayout();
            this.contextMenuStripSources.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Status});
            this.dataGridView.ContextMenuStrip = this.contextMenuStripSources;
            this.dataGridView.Location = new System.Drawing.Point(12, 68);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(868, 483);
            this.dataGridView.TabIndex = 0;
            // 
            // Source
            // 
            this.Source.ContextMenuStrip = this.contextMenuStripErase;
            this.Source.HeaderText = "Datenquelle";
            this.Source.Name = "Source";
            // 
            // contextMenuStripErase
            // 
            this.contextMenuStripErase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEraseCell});
            this.contextMenuStripErase.Name = "contextMenuStripErase";
            this.contextMenuStripErase.Size = new System.Drawing.Size(152, 26);
            // 
            // toolStripMenuItemEraseCell
            // 
            this.toolStripMenuItemEraseCell.Name = "toolStripMenuItemEraseCell";
            this.toolStripMenuItemEraseCell.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemEraseCell.Text = "Lösche Eintrag";
            this.toolStripMenuItemEraseCell.Click += new System.EventHandler(this.toolStripMenuItemEraseCell_Click);
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // contextMenuStripSources
            // 
            this.contextMenuStripSources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewSourceDirectory,
            this.toolStripMenuItemNewSourceFile,
            this.toolStripMenuItemErase});
            this.contextMenuStripSources.Name = "contextMenuStripSources";
            this.contextMenuStripSources.Size = new System.Drawing.Size(197, 70);
            // 
            // toolStripMenuItemNewSourceDirectory
            // 
            this.toolStripMenuItemNewSourceDirectory.Name = "toolStripMenuItemNewSourceDirectory";
            this.toolStripMenuItemNewSourceDirectory.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemNewSourceDirectory.Text = "Neues Quellverzeichnis";
            this.toolStripMenuItemNewSourceDirectory.Click += new System.EventHandler(this.toolStripMenuItemNewSourceDirectory_Click);
            // 
            // toolStripMenuItemNewSourceFile
            // 
            this.toolStripMenuItemNewSourceFile.Name = "toolStripMenuItemNewSourceFile";
            this.toolStripMenuItemNewSourceFile.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemNewSourceFile.Text = "Neue Quelldatei";
            this.toolStripMenuItemNewSourceFile.Click += new System.EventHandler(this.toolStripMenuItemNewSourceFile_Click);
            // 
            // toolStripMenuItemErase
            // 
            this.toolStripMenuItemErase.Name = "toolStripMenuItemErase";
            this.toolStripMenuItemErase.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemErase.Text = "Lösche Eintrag";
            this.toolStripMenuItemErase.Click += new System.EventHandler(this.toolStripMenuItemErase_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadConfig.TabIndex = 1;
            this.buttonLoadConfig.Text = "Lade Konfiguration";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // buttonStartBackup
            // 
            this.buttonStartBackup.Location = new System.Drawing.Point(324, 12);
            this.buttonStartBackup.Name = "buttonStartBackup";
            this.buttonStartBackup.Size = new System.Drawing.Size(150, 23);
            this.buttonStartBackup.TabIndex = 2;
            this.buttonStartBackup.Text = "Starte Backup";
            this.buttonStartBackup.UseVisualStyleBackColor = true;
            this.buttonStartBackup.Click += new System.EventHandler(this.buttonStartBackup_Click);
            // 
            // buttonRecoveryFile
            // 
            this.buttonRecoveryFile.Location = new System.Drawing.Point(480, 12);
            this.buttonRecoveryFile.Name = "buttonRecoveryFile";
            this.buttonRecoveryFile.Size = new System.Drawing.Size(150, 23);
            this.buttonRecoveryFile.TabIndex = 3;
            this.buttonRecoveryFile.Text = "Datei wiederherstellen";
            this.buttonRecoveryFile.UseVisualStyleBackColor = true;
            this.buttonRecoveryFile.Click += new System.EventHandler(this.buttonRecoveryFile_Click);
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(168, 12);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(150, 23);
            this.buttonSaveConfig.TabIndex = 4;
            this.buttonSaveConfig.Text = "Speichere Konfiguration";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // comboBoxTarget
            // 
            this.comboBoxTarget.FormattingEnabled = true;
            this.comboBoxTarget.Location = new System.Drawing.Point(12, 41);
            this.comboBoxTarget.Name = "comboBoxTarget";
            this.comboBoxTarget.Size = new System.Drawing.Size(306, 21);
            this.comboBoxTarget.TabIndex = 5;
            // 
            // buttonResetDirectorys
            // 
            this.buttonResetDirectorys.Location = new System.Drawing.Point(636, 12);
            this.buttonResetDirectorys.Name = "buttonResetDirectorys";
            this.buttonResetDirectorys.Size = new System.Drawing.Size(150, 23);
            this.buttonResetDirectorys.TabIndex = 6;
            this.buttonResetDirectorys.Text = "Verzeichnisse zurücksetzen";
            this.buttonResetDirectorys.UseVisualStyleBackColor = true;
            this.buttonResetDirectorys.Click += new System.EventHandler(this.buttonResetDirectorys_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 563);
            this.Controls.Add(this.buttonResetDirectorys);
            this.Controls.Add(this.comboBoxTarget);
            this.Controls.Add(this.buttonSaveConfig);
            this.Controls.Add(this.buttonRecoveryFile);
            this.Controls.Add(this.buttonStartBackup);
            this.Controls.Add(this.buttonLoadConfig);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStripErase.ResumeLayout(false);
            this.contextMenuStripSources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.Button buttonStartBackup;
        private System.Windows.Forms.Button buttonRecoveryFile;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.ComboBox comboBoxTarget;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSources;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewSourceDirectory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewSourceFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemErase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripErase;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEraseCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button buttonResetDirectorys;
    }
}

