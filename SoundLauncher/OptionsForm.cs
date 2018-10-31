using System.Collections.Generic;
using System.Windows.Forms;

namespace SoundLauncher
{
    public partial class OptionsForm : Form
    {
        private KeysConverter m_converter;

        private TextBox[] m_textBoxes;

        public OptionsForm()
        {
            InitializeComponent();
            m_converter = new KeysConverter();
            m_textBoxes = new TextBox[] { textBox0,
                                          textBox1,
                                          textBox2,
                                          textBox3,
                                          textBox4,
                                          textBox5,
                                          textBox6,
                                          textBox7,
                                          textBox8,
                                          textBox9 };
        }

        public IList<Keys> GetKeys()
        {
            var keys = new List<Keys>();
            foreach (var textbox in m_textBoxes)
                if (textbox.Tag != null)
                    keys.Add((Keys)textbox.Tag);

            return keys;
        }

        public void Init(IList<Keys> keys)
        {
            for (int i = 0; i < keys.Count && i < m_textBoxes.Length; i++)
            {
                m_textBoxes[i].Text = m_converter.ConvertToString(keys[i]);
                m_textBoxes[i].Tag = keys[i];
            }
        }

        private string ValidateKeys()
        {
            var keys = GetKeys();
            if (keys.Count == 0)
                return @"At least one key must be set.";

            for (int i = 0; i < m_textBoxes.Length; i++)
            {
                var textBox = m_textBoxes[i];
                if (textBox.Tag == null)
                {
                    if (i < keys.Count)
                        return @"No gaps may be defined.";
                    else
                        break;
                }
            }

            var keysHash = new HashSet<Keys>(keys);
            if(keysHash.Count != keys.Count)
                return @"Two identical keys must not be defined.";

            return null;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            e.Handled = true;
            e.SuppressKeyPress = true;
            textBox.Tag = e.KeyCode;
            textBox.Text = m_converter.ConvertToString(e.KeyData);
        }

        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Ok_Click(object sender, System.EventArgs e)
        {
            var message = ValidateKeys();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClearAll_Click(object sender, System.EventArgs e)
        {
            foreach (var tb in m_textBoxes)
            {
                tb.Text = string.Empty;
                tb.Tag = null;
            }
        }
    }
}
