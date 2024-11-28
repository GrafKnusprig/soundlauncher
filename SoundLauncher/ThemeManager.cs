using System.Drawing;
using System.Windows.Forms;

namespace SoundLauncher
{
    internal static class ThemeManager
    {

        internal static ITheme currentTheme;

        public static void ApplyTheme(Control control)
        {
            // Generic property application
            SetPropertyIfExists(control, "BackColor", currentTheme.Background);
            SetPropertyIfExists(control, "ForeColor", currentTheme.Foreground);

            // Specific controls
            if (control is Button button)
            {
                button.FlatAppearance.BorderColor = currentTheme.Highlight;
            }
            else if (control is DataGridView dgv)
            {
                StyleDataGridView(dgv);
            }
            else if (control is NAudio.Gui.VolumeSlider volumeSlider)
            {
                StyleVolumeSlider(volumeSlider);
            }
            else if (control is Panel panel)
            {
                panel.BorderStyle = BorderStyle.None;
            }

            // Recursively apply theme to child controls
            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
        }

        private static void StyleDataGridView(DataGridView dgv)
        {
            // General styles
            dgv.BackgroundColor = currentTheme.Background;
            dgv.ForeColor = currentTheme.Foreground;
            dgv.GridColor = currentTheme.Highlight;
            dgv.BorderStyle = BorderStyle.None;

            // Column headers
            dgv.EnableHeadersVisualStyles = false; // Allow custom styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = currentTheme.ButtonBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = currentTheme.ButtonForeground;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Advanced Column Header Borders
            dgv.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;

            // Row headers
            dgv.RowHeadersDefaultCellStyle.BackColor = currentTheme.ButtonBackground;
            dgv.RowHeadersDefaultCellStyle.ForeColor = currentTheme.ButtonForeground;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = currentTheme.Highlight;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = currentTheme.ButtonForeground;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Advanced Row Header Borders
            dgv.AdvancedRowHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedRowHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedRowHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedRowHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;

            // Row styles
            dgv.DefaultCellStyle.BackColor = currentTheme.Background;
            dgv.DefaultCellStyle.ForeColor = currentTheme.Foreground;
            dgv.DefaultCellStyle.SelectionBackColor = currentTheme.Highlight;
            dgv.DefaultCellStyle.SelectionForeColor = currentTheme.ButtonForeground;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = currentTheme.AlternatingRow;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = currentTheme.Foreground;
        }

        private static void StyleVolumeSlider(NAudio.Gui.VolumeSlider volumeSlider)
        {
            // Custom highlight color for the slider
            volumeSlider.BackColor = currentTheme.Background;
            volumeSlider.ForeColor = currentTheme.VolumeSliderHighlight; // Use the custom pastel highlight
        }

        // Generic property setter
        private static void SetPropertyIfExists(object obj, string propertyName, object value)
        {
            var prop = obj.GetType().GetProperty(propertyName);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value);
            }
        }
    }
}
