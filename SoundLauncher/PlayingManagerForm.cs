using SoundLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SoundLauncher
{
    public partial class PlayingManagerForm : Form
    {
        #region members

        private SoundManager m_soundManager;

        #endregion

        #region ctor

        public PlayingManagerForm(SoundManager soundManager)
        {
            InitializeComponent();
            gvPlayingManager.Columns["gc_Loop"].DefaultCellStyle.NullValue = null;
            m_soundManager = soundManager;
            soundManager.CurrentlyPlayingSoundsChanged += OnCurrentlyPlayingSoundsChanged;
            UpdatePlayingFiles(m_soundManager.CurrentlyPlayingSounds);
            ThemeManager.ApplyTheme(this);
        }

        #endregion

        #region methods

        private void UpdatePlayingFiles(List<int> ids)
        {
            ids.Sort();
            gvPlayingManager.Rows.Clear();
            foreach (var id in ids)
            {
                var file = m_soundManager.GetFileNameForId(id);
                var isLoop = m_soundManager.IsEndlessLoop(id);
                if (isLoop)
                    gvPlayingManager.Rows.Add(id, Resources.repeat, file);
                else
                    gvPlayingManager.Rows.Add(id, null, file);
            }
        }

        private void gvPlayingManager_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                m_soundManager.StopSound((int)gvPlayingManager.Rows[e.RowIndex].Cells[0].Value);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            m_soundManager.CurrentlyPlayingSoundsChanged -= OnCurrentlyPlayingSoundsChanged;
        }

        #endregion

        #region event methods

        public void OnCurrentlyPlayingSoundsChanged(object sender, List<int> codes)
        {
            UpdatePlayingFiles(codes);
        }

        private void gvPlayingManager_SelectionChanged(object sender, System.EventArgs e)
        {
            gvPlayingManager.ClearSelection();
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
