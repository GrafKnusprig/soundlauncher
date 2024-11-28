using System;
using System.Windows.Forms;

namespace SoundLauncher
{
    internal class ScrollbarHelper
    {
        internal void LinkScrollBarToDataGridView(DataGridView gridView, ThemedScrollBar verticalScrollBar, ThemedScrollBar horizontalScrollBar = null)
        {
            // Hide default scrollbars
            gridView.ScrollBars = ScrollBars.None;

            // Link vertical scrollbar
            if (verticalScrollBar != null)
            {
                // Apply ThemeManager.currentTheme colors to the scrollbar
                verticalScrollBar.TrackColor = ThemeManager.currentTheme.Background;
                verticalScrollBar.ThumbColor = ThemeManager.currentTheme.Highlight;
                verticalScrollBar.BorderColor = ThemeManager.currentTheme.HeaderBorder;

                verticalScrollBar.Scroll += (s, e) =>
                {
                    gridView.FirstDisplayedScrollingRowIndex = verticalScrollBar.Value;
                };

                gridView.RowsAdded += (s, e) => UpdateVerticalScrollBar(gridView, verticalScrollBar);
                gridView.RowsRemoved += (s, e) => UpdateVerticalScrollBar(gridView, verticalScrollBar);
            }

            // Link horizontal scrollbar
            if (horizontalScrollBar != null)
            {
                // Apply ThemeManager.currentTheme colors to the scrollbar
                horizontalScrollBar.TrackColor = ThemeManager.currentTheme.Background;
                horizontalScrollBar.ThumbColor = ThemeManager.currentTheme.Highlight;
                horizontalScrollBar.BorderColor = ThemeManager.currentTheme.HeaderBorder;

                horizontalScrollBar.Scroll += (s, e) =>
                {
                    gridView.HorizontalScrollingOffset = horizontalScrollBar.Value;
                };

                gridView.ColumnWidthChanged += (s, e) => UpdateHorizontalScrollBar(gridView, horizontalScrollBar);
            }

            // Update scrollbars dynamically
            gridView.Resize += (s, e) =>
            {
                if (verticalScrollBar != null) UpdateVerticalScrollBar(gridView, verticalScrollBar);
                if (horizontalScrollBar != null) UpdateHorizontalScrollBar(gridView, horizontalScrollBar);
            };
        }
        private void UpdateVerticalScrollBar(DataGridView gridView, ThemedScrollBar verticalScrollBar)
        {
            int visibleRows = gridView.DisplayedRowCount(false);
            int totalRows = gridView.RowCount;

            verticalScrollBar.Maximum = Math.Max(0, totalRows - visibleRows);
            verticalScrollBar.LargeChange = visibleRows;
            verticalScrollBar.Value = Math.Min(verticalScrollBar.Value, verticalScrollBar.Maximum);
            verticalScrollBar.Visible = visibleRows < totalRows;
        }

        private void UpdateHorizontalScrollBar(DataGridView gridView, ThemedScrollBar horizontalScrollBar)
        {
            int totalWidth = gridView.DisplayRectangle.Width;
            int visibleWidth = gridView.ClientSize.Width;

            horizontalScrollBar.Maximum = Math.Max(0, totalWidth - visibleWidth);
            horizontalScrollBar.LargeChange = visibleWidth;
            horizontalScrollBar.Value = Math.Min(horizontalScrollBar.Value, horizontalScrollBar.Maximum);
            horizontalScrollBar.Visible = totalWidth > visibleWidth;
        }
    }
}
