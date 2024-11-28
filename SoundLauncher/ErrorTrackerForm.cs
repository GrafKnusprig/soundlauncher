using System;
using System.Windows.Forms;

namespace SoundLauncher
{
    public partial class ErrorTrackerForm : Form
    {
        public ErrorTrackerForm()
        {
            InitializeComponent();
        }

        public void Init(ErrorTracker errorTracker)
        {
            if (errorTracker.HasError)
            {
                textBox.Text = errorTracker.ErrorMessage;
                errorTracker.HasNewError = false;
            }
        }

        #region overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkModeHelper.EnableDarkMode(this.Handle);
        }
        #endregion
    }
}
