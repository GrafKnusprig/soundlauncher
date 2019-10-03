namespace SoundLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gvLibrary = new System.Windows.Forms.DataGridView();
            this.gc_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvLibraryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmLoadAudioFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddAudioFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteSelectedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.gvDevice = new System.Windows.Forms.DataGridView();
            this.gc_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gc_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConfigFile = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.volumeSlider = new NAudio.Gui.VolumeSlider();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadAudioFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAudioFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playingManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.hookedKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.errorLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.scDataGrids = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.gvLibrary)).BeginInit();
            this.gvLibraryContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDataGrids)).BeginInit();
            this.scDataGrids.Panel1.SuspendLayout();
            this.scDataGrids.Panel2.SuspendLayout();
            this.scDataGrids.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvLibrary
            // 
            this.gvLibrary.AllowUserToAddRows = false;
            this.gvLibrary.AllowUserToDeleteRows = false;
            this.gvLibrary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLibrary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_code,
            this.gc_file});
            this.gvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLibrary.Location = new System.Drawing.Point(0, 0);
            this.gvLibrary.Name = "gvLibrary";
            this.gvLibrary.ReadOnly = true;
            this.gvLibrary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLibrary.Size = new System.Drawing.Size(851, 225);
            this.gvLibrary.TabIndex = 1;
            this.gvLibrary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGrid_CellClick);
            this.gvLibrary.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvLibrary_MouseClick);
            // 
            // gc_code
            // 
            this.gc_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gc_code.HeaderText = "Code";
            this.gc_code.Name = "gc_code";
            this.gc_code.ReadOnly = true;
            this.gc_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gc_code.Width = 38;
            // 
            // gc_file
            // 
            this.gc_file.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_file.HeaderText = "Music File";
            this.gc_file.Name = "gc_file";
            this.gc_file.ReadOnly = true;
            this.gc_file.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gvLibraryContextMenu
            // 
            this.gvLibraryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLoadAudioFiles,
            this.tsmAddAudioFiles,
            this.tsmDeleteSelectedFiles});
            this.gvLibraryContextMenu.Name = "gvLibraryContextMenu";
            this.gvLibraryContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // tsmLoadAudioFiles
            // 
            this.tsmLoadAudioFiles.Name = "tsmLoadAudioFiles";
            this.tsmLoadAudioFiles.Size = new System.Drawing.Size(180, 22);
            this.tsmLoadAudioFiles.Text = "Load Audio Files";
            this.tsmLoadAudioFiles.Click += new System.EventHandler(this.loadAudioFilesToolStripMenuItem_Click);
            // 
            // tsmAddAudioFiles
            // 
            this.tsmAddAudioFiles.Name = "tsmAddAudioFiles";
            this.tsmAddAudioFiles.Size = new System.Drawing.Size(180, 22);
            this.tsmAddAudioFiles.Text = "Add Audio Files";
            this.tsmAddAudioFiles.Click += new System.EventHandler(this.addAudioFilesToolStripMenuItem_Click);
            // 
            // tsmDeleteSelectedFiles
            // 
            this.tsmDeleteSelectedFiles.Name = "tsmDeleteSelectedFiles";
            this.tsmDeleteSelectedFiles.Size = new System.Drawing.Size(180, 22);
            this.tsmDeleteSelectedFiles.Text = "Delete Selected Files";
            this.tsmDeleteSelectedFiles.Click += new System.EventHandler(this.deleteSelectedAudioFilesToolStripMenuItem_Click);
            // 
            // gvDevice
            // 
            this.gvDevice.AllowUserToAddRows = false;
            this.gvDevice.AllowUserToDeleteRows = false;
            this.gvDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_check,
            this.gc_device});
            this.gvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDevice.Location = new System.Drawing.Point(0, 0);
            this.gvDevice.Name = "gvDevice";
            this.gvDevice.Size = new System.Drawing.Size(851, 142);
            this.gvDevice.TabIndex = 1;
            // 
            // gc_check
            // 
            this.gc_check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gc_check.HeaderText = "Check";
            this.gc_check.Name = "gc_check";
            this.gc_check.Width = 44;
            // 
            // gc_device
            // 
            this.gc_device.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_device.HeaderText = "Device";
            this.gc_device.Name = "gc_device";
            this.gc_device.ReadOnly = true;
            this.gc_device.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(87, 6);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(576, 20);
            this.tbFilePath.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblConfigFile);
            this.panel1.Controls.Add(this.lblVolume);
            this.panel1.Controls.Add(this.volumeSlider);
            this.panel1.Controls.Add(this.tbFilePath);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 34);
            this.panel1.TabIndex = 0;
            // 
            // lblConfigFile
            // 
            this.lblConfigFile.AutoSize = true;
            this.lblConfigFile.Location = new System.Drawing.Point(3, 9);
            this.lblConfigFile.Name = "lblConfigFile";
            this.lblConfigFile.Size = new System.Drawing.Size(78, 13);
            this.lblConfigFile.TabIndex = 5;
            this.lblConfigFile.Text = "Loaded config:";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(669, 9);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 4;
            this.lblVolume.Text = "Master:";
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(717, 6);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(124, 21);
            this.volumeSlider.TabIndex = 2;
            this.volumeSlider.VolumeChanged += new System.EventHandler(this.volumeSlider_VolumeChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(851, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadLibraryToolStripMenuItem,
            this.saveLibraryAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadAudioFilesToolStripMenuItem,
            this.addAudioFilesToolStripMenuItem,
            this.deleteSelectedFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadLibraryToolStripMenuItem
            // 
            this.loadLibraryToolStripMenuItem.Name = "loadLibraryToolStripMenuItem";
            this.loadLibraryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadLibraryToolStripMenuItem.Text = "Load Library";
            this.loadLibraryToolStripMenuItem.Click += new System.EventHandler(this.loadLibraryToolStripMenuItem_Click);
            // 
            // saveLibraryAsToolStripMenuItem
            // 
            this.saveLibraryAsToolStripMenuItem.Name = "saveLibraryAsToolStripMenuItem";
            this.saveLibraryAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveLibraryAsToolStripMenuItem.Text = "Save Library As...";
            this.saveLibraryAsToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // loadAudioFilesToolStripMenuItem
            // 
            this.loadAudioFilesToolStripMenuItem.Name = "loadAudioFilesToolStripMenuItem";
            this.loadAudioFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadAudioFilesToolStripMenuItem.Text = "Load Audio Files";
            this.loadAudioFilesToolStripMenuItem.Click += new System.EventHandler(this.loadAudioFilesToolStripMenuItem_Click);
            // 
            // addAudioFilesToolStripMenuItem
            // 
            this.addAudioFilesToolStripMenuItem.Name = "addAudioFilesToolStripMenuItem";
            this.addAudioFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAudioFilesToolStripMenuItem.Text = "Add Audio Files";
            this.addAudioFilesToolStripMenuItem.Click += new System.EventHandler(this.addAudioFilesToolStripMenuItem_Click);
            // 
            // deleteSelectedFilesToolStripMenuItem
            // 
            this.deleteSelectedFilesToolStripMenuItem.Name = "deleteSelectedFilesToolStripMenuItem";
            this.deleteSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteSelectedFilesToolStripMenuItem.Text = "Delete Selected Files";
            this.deleteSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedAudioFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickToPlayToolStripMenuItem,
            this.playingManagerToolStripMenuItem,
            this.toolStripSeparator3,
            this.hookedKeysToolStripMenuItem,
            this.recalculateCodesToolStripMenuItem,
            this.toolStripSeparator4,
            this.errorLogToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // clickToPlayToolStripMenuItem
            // 
            this.clickToPlayToolStripMenuItem.CheckOnClick = true;
            this.clickToPlayToolStripMenuItem.Name = "clickToPlayToolStripMenuItem";
            this.clickToPlayToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.clickToPlayToolStripMenuItem.Text = "Click to Play";
            // 
            // playingManagerToolStripMenuItem
            // 
            this.playingManagerToolStripMenuItem.Name = "playingManagerToolStripMenuItem";
            this.playingManagerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playingManagerToolStripMenuItem.Text = "Playing Manager";
            this.playingManagerToolStripMenuItem.Click += new System.EventHandler(this.playingManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // hookedKeysToolStripMenuItem
            // 
            this.hookedKeysToolStripMenuItem.Name = "hookedKeysToolStripMenuItem";
            this.hookedKeysToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.hookedKeysToolStripMenuItem.Text = "Hooked Keys";
            this.hookedKeysToolStripMenuItem.Click += new System.EventHandler(this.hookedKeysToolStripMenuItem_Click);
            // 
            // recalculateCodesToolStripMenuItem
            // 
            this.recalculateCodesToolStripMenuItem.Name = "recalculateCodesToolStripMenuItem";
            this.recalculateCodesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.recalculateCodesToolStripMenuItem.Text = "Recalculate Codes";
            this.recalculateCodesToolStripMenuItem.Click += new System.EventHandler(this.recalculateCodesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(167, 6);
            // 
            // errorLogToolStripMenuItem
            // 
            this.errorLogToolStripMenuItem.Name = "errorLogToolStripMenuItem";
            this.errorLogToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.errorLogToolStripMenuItem.Text = "Error Log";
            this.errorLogToolStripMenuItem.Click += new System.EventHandler(this.errorLogToolStripMenuItem_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1, 433);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Nothing playing.";
            // 
            // scDataGrids
            // 
            this.scDataGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scDataGrids.Location = new System.Drawing.Point(0, 59);
            this.scDataGrids.Name = "scDataGrids";
            this.scDataGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDataGrids.Panel1
            // 
            this.scDataGrids.Panel1.Controls.Add(this.gvLibrary);
            // 
            // scDataGrids.Panel2
            // 
            this.scDataGrids.Panel2.Controls.Add(this.gvDevice);
            this.scDataGrids.Size = new System.Drawing.Size(851, 371);
            this.scDataGrids.SplitterDistance = 225;
            this.scDataGrids.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 448);
            this.Controls.Add(this.scDataGrids);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(867, 250);
            this.Name = "MainForm";
            this.Text = "SoundLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gvLibrary)).EndInit();
            this.gvLibraryContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.scDataGrids.Panel1.ResumeLayout(false);
            this.scDataGrids.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDataGrids)).EndInit();
            this.scDataGrids.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvLibrary;
        private System.Windows.Forms.DataGridView gvDevice;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Panel panel1;
        private NAudio.Gui.VolumeSlider volumeSlider;
        private System.Windows.Forms.Label lblConfigFile;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hookedKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAudioFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addAudioFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripMenuItem clickToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_file;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gc_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_device;
        private System.Windows.Forms.SplitContainer scDataGrids;
        private System.Windows.Forms.ContextMenuStrip gvLibraryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmLoadAudioFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmAddAudioFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteSelectedFiles;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playingManagerToolStripMenuItem;
    }
}

