using System;
using System.Runtime.InteropServices;

namespace SoundLauncher
{
    internal class DarkModeHelper
    {
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [DllImport("dwmapi.dll", SetLastError = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int pvAttribute, int cbAttribute);

        public static void EnableDarkMode(IntPtr handle)
        {
            int isDarkMode = 1; // Enable dark mode
            DwmSetWindowAttribute(handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref isDarkMode, sizeof(int));
        }
    }
}
