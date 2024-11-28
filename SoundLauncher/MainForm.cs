using NAudio.Wave;
using SoundLauncher.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoundLauncher
{
    public partial class MainForm : Form
    {
        #region members

        private string m_libraryFileExt = @".sll";

        private string m_openMp3FileFilter = @"mp3 files (*.mp3)|*.mp3";

        private string m_libraryFileFilter = @"sll files (*.sll)|*.sll";

        private int m_errorTimerIntervall = 500;

        private Timer m_errorTimer;

        private Color m_defaultMenuColor, m_subMenuDefaultColor;

        private ErrorTracker m_errorTracker;

        private string m_actualLibraryFilePath;

        private bool m_dirty;

        private KeyManager m_keyManager;

        private SoundManager m_soundManager;

        #endregion

        #region properties

        private string ActualLibraryFilePath
        {
            get { return m_actualLibraryFilePath; }
            set { m_actualLibraryFilePath = value; tbFilePath.Text = value; }
        }

        public bool Dirty
        {
            get { return m_dirty; }
            private set
            {
                if (m_dirty != value)
                {
                    if (value)
                        Text += "*";
                    else
                        Text = Text.Replace("*", "");
                }
                m_dirty = value;
            }
        }

        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
            Initialize();
            ThemeManager.ApplyTheme(this); // Apply theme to the form and all its controls
        }

        #endregion

        #region methods

        private void Initialize()
        {
            m_keyManager = new KeyManager();
            m_keyManager.CodeFired += OnCodeFired;
            m_keyManager.CodeValueChanged += OnCodeValueChanged;

            m_soundManager = new SoundManager();
            m_soundManager.PlayingChanged += OnPlayingChanged;

            m_errorTracker = new ErrorTracker();
            m_errorTracker.NewError += OnNewError;

            m_defaultMenuColor = optionsToolStripMenuItem.BackColor;
            m_subMenuDefaultColor = errorLogToolStripMenuItem.BackColor;

            m_errorTimer = new Timer();
            m_errorTimer.Tick += m_errorTimer_Tick;
            m_errorTimer.Interval = m_errorTimerIntervall;

            for (int n = -1; n < WaveOut.DeviceCount; n++)
                gvDevice.Rows.Add(new object[] { false, WaveOut.GetCapabilities(n).ProductName });

            LoadFromConfigFile();
            ClearCodePathLibrary();
            LoadLibraryFile(ActualLibraryFilePath);

            ConfigUpdated();

            gvDevice.CellValueChanged += devicegrid_CellValueChanged;
            gvDevice.CellMouseUp += devicegrid_CellMouseUP;
            gvDevice.ScrollBars = ScrollBars.None;

        }

        private void SaveChangesIfNecessary()
        {
            if (Dirty)
                if (m_soundManager.HasSounds)
                    if (MessageBox.Show(Resources.SaveChanges, Resources.ClosingSoundLauncher, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(ActualLibraryFilePath))
                            ShowSaveFileAsDialog();
                        else
                            m_soundManager.SaveLibraryToFile(ActualLibraryFilePath);
                    }
            Dirty = false;
        }

        private void ConfigUpdated()
        {
            for (int i = 0; i < gvDevice.Rows.Count; i++)
            {
                gvDevice.Rows[i].Cells[0].Value = false;
                if (m_soundManager.SelectedAudioDevices.Contains(i - 1))
                    gvDevice.Rows[i].Cells[0].Value = true;
            }

            volumeSlider.Volume = m_soundManager.Volume;
        }

        private void SaveSettings()
        {
            var userSettings = UserSettings.Instance;
            userSettings.ActualLibraryFilePath = ActualLibraryFilePath;
            userSettings.ClickToPlay = clickToPlayToolStripMenuItem.Checked;
        }

        private void LoadSettings()
        {
            var userSettings = UserSettings.Instance;
            ActualLibraryFilePath = userSettings.ActualLibraryFilePath;
            clickToPlayToolStripMenuItem.Checked = userSettings.ClickToPlay;
        }

        private void SaveToConfigFile()
        {
            try
            {
                SaveSettings();
                m_soundManager.SaveSettings();
                m_keyManager.SaveSettings();
                UserSettings.Instance.Save();
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        private void LoadFromConfigFile()
        {
            try
            {
                LoadSettings();
                m_soundManager.LoadSettings();
                m_keyManager.LoadSettings();
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        private void ClearCodePathLibrary()
        {
            m_soundManager.ClearLibrary();
            gvLibrary.Rows.Clear();
            gvLibrary.Rows.Add(new[] { "0", Resources.StopAllPlaybacks });
        }

        private void LoadLibraryFile(string path)
        {
            m_soundManager.LoadLibrary(path, m_errorTracker);
            foreach (var row in m_soundManager.Library)
                gvLibrary.Rows.Add(row.Key, row.Value);
            ActualLibraryFilePath = path;
        }

        private void ShowSaveFileAsDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = m_libraryFileExt;
            saveFileDialog.FileName = Resources.SoundLauncher;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                m_soundManager.SaveLibraryToFile(fileName);
                ActualLibraryFilePath = fileName;
            }
        }

        private void AddErrorMessage(string message)
        {
            m_errorTracker.AddErrorMessage(message);
            CheckErrorMessage();
        }

        private void CheckErrorMessage()
        {
            if (m_errorTracker.HasNewError && !m_errorTimer.Enabled)
                m_errorTimer.Start();
        }

        private void AddEntryToFileList(string file)
        {
            var line = gvLibrary.Rows.Add();
            var code = m_keyManager.GetCodeString(line);
            if (m_soundManager.Library.ContainsKey(code))
            {
                AddErrorMessage(string.Format(Resources.DirectoryAllreadyContainsKey, code));
                gvLibrary.Rows.RemoveAt(line);
                return;
            }
            m_soundManager.Library.Add(code, file);
            gvLibrary.Rows[line].Cells[0].Value = code;
            gvLibrary.Rows[line].Cells[1].Value = file;
            Dirty = true;
        }

        #endregion

        #region event methods

        private void OnPlayingChanged(object sender, bool e)
        {
            if (e)
                lblStatus.Text = Resources.NowPlaying;
            else
                lblStatus.Text = Resources.NothingPlaying;
        }

        private void OnNewError(object sender, string e)
        {
            CheckErrorMessage();
        }

        private void OnCodeValueChanged(object sender, CodeEvent e)
        {
            lblStatus.Text = string.Format(Resources.Code, e.Code);
        }

        private void OnCodeFired(object sender, CodeEvent e)
        {
            m_soundManager.PlayCode(e.Code, false, m_errorTracker);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveChangesIfNecessary();
            SaveToConfigFile();
        }

        private void devicegrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gc_check.Index && e.RowIndex != -1)
            {
                if ((bool)gvDevice.Rows[e.RowIndex].Cells[0].Value)
                    m_soundManager.SelectedAudioDevices.Add(e.RowIndex - 1);
                else
                    m_soundManager.SelectedAudioDevices.Remove(e.RowIndex - 1);
            }
        }

        private void devicegrid_CellMouseUP(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == gc_check.Index && e.RowIndex != -1)
                gvDevice.EndEdit();
        }

        private void hookedKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsDialog = new OptionsForm();
            optionsDialog.Init(m_keyManager.HookedKeys);
            optionsDialog.StartPosition = FormStartPosition.CenterParent;
            if (optionsDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_keyManager.HookedKeys.Clear();
                m_keyManager.HookedKeys.AddRange(optionsDialog.GetKeys());
            }
        }

        private void loadLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = m_libraryFileFilter;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadLibraryFile(openFileDialog.FileName);
            }
            Dirty = false;
        }

        private void errorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var errorTrackerDialog = new ErrorTrackerForm();
            errorTrackerDialog.StartPosition = FormStartPosition.CenterParent;
            errorTrackerDialog.Init(m_errorTracker);
            m_errorTimer.Stop();

            optionsToolStripMenuItem.BackColor = m_defaultMenuColor;
            errorLogToolStripMenuItem.BackColor = m_subMenuDefaultColor;

            errorTrackerDialog.ShowDialog(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadAudioFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = m_openMp3FileFilter;
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ActualLibraryFilePath = string.Empty;
                ClearCodePathLibrary();
                var files = openFileDialog.FileNames;
                foreach (var file in files)
                    AddEntryToFileList(file);
            }
        }

        private void saveLibraryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSaveFileAsDialog();
            Dirty = false;
        }

        private void addAudioFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = m_openMp3FileFilter;
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ActualLibraryFilePath = string.Empty;
                var files = openFileDialog.FileNames;
                foreach (var file in files)
                    AddEntryToFileList(file);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChangesIfNecessary();
            ClearCodePathLibrary();
            ActualLibraryFilePath = string.Empty;
        }

        private void recalculateCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if recalculate is necessary
            bool changeNeeded = false;
            var codesList = m_soundManager.Library.Keys.ToList();
            for (int i = 0; i < codesList.Count; i++)
                if (m_keyManager.GetCodeString(i + 1) != codesList[i])
                {
                    changeNeeded = true;
                    break;
                }

            if (changeNeeded)
            {
                var values = m_soundManager.Library.Values.ToList();
                ClearCodePathLibrary();
                foreach (var value in values)
                {
                    AddEntryToFileList(value);
                }
            }
        }

        private void mainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clickToPlayToolStripMenuItem.Checked)
                if (e.ColumnIndex == 1 && e.RowIndex == 0)
                    m_soundManager.StopAllCurrentPlaying();
                else if (e.ColumnIndex == 1 && e.RowIndex > 0)
                    m_soundManager.PlayCode((string)gvLibrary.Rows[e.RowIndex].Cells[0].Value, false, m_errorTracker);
        }

        private void deleteSelectedAudioFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = gvLibrary.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                if (row.Index == 0)
                    continue;
                m_soundManager.Library.Remove(m_soundManager.Library.ElementAt(row.Index - 1).Key);
                gvLibrary.Rows.Remove(row);
                Dirty = true;
            }
        }

        private void volumeSlider_VolumeChanged(object sender, EventArgs e)
        {
            m_soundManager.Volume = volumeSlider.Volume;
        }

        private void playingManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var playingManagerForm = (Application.OpenForms["PlayingManagerForm"] as PlayingManagerForm);
            if (playingManagerForm != null)
            {
                playingManagerForm.BringToFront();
            }
            else
            {
                playingManagerForm = new PlayingManagerForm(m_soundManager);
                playingManagerForm.StartPosition = FormStartPosition.CenterParent;
                playingManagerForm.Show();
            }
        }

        private void gvLibrary_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = gvLibrary.HitTest(e.X, e.Y).RowIndex;
                int columnIndex = gvLibrary.HitTest(e.X, e.Y).ColumnIndex;

                ContextMenu m = new ContextMenu();
                MenuItem loop = new MenuItem("Endless Loop");

                loop.Click += (sen, args) =>
                {
                    m_soundManager.PlayCode((string)gvLibrary.Rows[rowIndex].Cells[0].Value, true, m_errorTracker);
                };

                m.MenuItems.Add(loop);

                if (columnIndex == 1 && rowIndex > 0)
                    m.Show(gvLibrary, new Point(e.X, e.Y));
            }
        }

        private void m_errorTimer_Tick(object sender, EventArgs e)
        {
            if (optionsToolStripMenuItem.BackColor != Color.Red)
            {
                optionsToolStripMenuItem.BackColor = Color.Red;
                errorLogToolStripMenuItem.BackColor = Color.Red;
            }
            else
            {
                optionsToolStripMenuItem.BackColor = m_defaultMenuColor;
                errorLogToolStripMenuItem.BackColor = m_subMenuDefaultColor;
            }
        }

        #endregion

        #region overrides

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkModeHelper.EnableDarkMode(this.Handle);
        }

        #endregion
    }
}
