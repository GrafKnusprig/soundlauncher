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
    }
}
