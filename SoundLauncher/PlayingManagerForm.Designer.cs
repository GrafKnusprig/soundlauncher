namespace SoundLauncher
{
    partial class PlayingManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayingManagerForm));
            this.gvPlayingManager = new System.Windows.Forms.DataGridView();
            this.gc_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_Loop = new System.Windows.Forms.DataGridViewImageColumn();
            this.gc_File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayingManager)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPlayingManager
            // 
            this.gvPlayingManager.AllowUserToAddRows = false;
            this.gvPlayingManager.AllowUserToDeleteRows = false;
            this.gvPlayingManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPlayingManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_Code,
            this.gc_Loop,
            this.gc_File});
            this.gvPlayingManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPlayingManager.Location = new System.Drawing.Point(0, 0);
            this.gvPlayingManager.Name = "gvPlayingManager";
            this.gvPlayingManager.ReadOnly = true;
            this.gvPlayingManager.Size = new System.Drawing.Size(540, 356);
            this.gvPlayingManager.TabIndex = 0;
            this.gvPlayingManager.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPlayingManager_CellClick);
            this.gvPlayingManager.SelectionChanged += new System.EventHandler(this.gvPlayingManager_SelectionChanged);
            // 
            // gc_Code
            // 
            this.gc_Code.HeaderText = "Id";
            this.gc_Code.Name = "gc_Code";
            this.gc_Code.ReadOnly = true;
            this.gc_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gc_Code.Visible = false;
            this.gc_Code.Width = 38;
            // 
            // gc_Loop
            // 
            this.gc_Loop.HeaderText = "Loop";
            this.gc_Loop.Name = "gc_Loop";
            this.gc_Loop.ReadOnly = true;
            this.gc_Loop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gc_Loop.Width = 38;
            // 
            // gc_File
            // 
            this.gc_File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_File.HeaderText = "Music File";
            this.gc_File.Name = "gc_File";
            this.gc_File.ReadOnly = true;
            this.gc_File.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlayingManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 356);
            this.Controls.Add(this.gvPlayingManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayingManagerForm";
            this.Text = "Playing Manager";
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayingManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPlayingManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_Code;
        private System.Windows.Forms.DataGridViewImageColumn gc_Loop;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_File;
    }
}