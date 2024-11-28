using System.Drawing;

namespace SoundLauncher
{
    internal interface ITheme
    {
        Color Background { get; }
        Color Foreground { get; }
        Color Highlight { get; }
        Color ButtonBackground { get; }
        Color ButtonForeground { get; }
        Color AlternatingRow { get; }
        Color AlternatingColumn { get; }
        Color HeaderBorder { get; }
        Color VolumeSliderHighlight { get; }
    }

    internal class DarkTealTheme : ITheme
    {
        public Color Background => Color.FromArgb(30, 30, 30);  // Dark background
        public Color Foreground => Color.White;                 // Text color
        public Color Highlight => Color.FromArgb(128, 203, 196); // Pastel teal
        public Color ButtonBackground => Color.FromArgb(50, 50, 50);
        public Color ButtonForeground => Color.White;
        public Color AlternatingRow => Color.FromArgb(40, 40, 40); // Slightly lighter rows
        public Color AlternatingColumn => Color.FromArgb(35, 35, 35);
        public Color HeaderBorder => Color.FromArgb(45, 45, 45);
        public Color VolumeSliderHighlight => Color.FromArgb(144, 224, 208); // Custom pastel teal for sliders
    }

    internal class DarkOrangeTheme : ITheme
    {
        public Color Background => Color.FromArgb(30, 30, 30);  // Dark background
        public Color Foreground => Color.White;                 // Text color
        public Color Highlight => Color.FromArgb(209, 84, 0); // Dark pastel orange
        public Color ButtonBackground => Color.FromArgb(50, 50, 50);
        public Color ButtonForeground => Color.White;
        public Color AlternatingRow => Color.FromArgb(40, 40, 40); // Slightly lighter rows
        public Color AlternatingColumn => Color.FromArgb(35, 35, 35);
        public Color HeaderBorder => Color.FromArgb(45, 45, 45);
        public Color VolumeSliderHighlight => Color.FromArgb(244, 177, 131); // Custom pastel orange for sliders
    }
}
