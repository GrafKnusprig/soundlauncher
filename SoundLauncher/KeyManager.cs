using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoundLauncher
{
    public class CodeEvent : EventArgs
    {
        public string Code { get; set; }
    }

    public class KeyManager
    {
        #region members

        private GlobalKeyboardHook m_globalKeyboardHook = new GlobalKeyboardHook();

        private string m_codeBuffer;

        private int m_keyStrokeInterval = 1000;

        private Timer m_codeTimer;

        #endregion

        #region properties / events

        public List<Keys> HookedKeys => m_globalKeyboardHook.HookedKeys;

        public EventHandler<CodeEvent> CodeFired;

        public EventHandler<CodeEvent> CodeValueChanged;

        #endregion

        #region ctor

        public KeyManager()
        {
            m_codeBuffer = string.Empty;
            m_codeTimer = new Timer();
            m_codeTimer.Tick += OnCodeTimerTick;
            m_codeTimer.Interval = m_keyStrokeInterval;
            m_globalKeyboardHook.KeyDown += OnHookedKeyDown;
        }

        #endregion

        #region methods

        public string GetCodeString(int value)
        {
            var baseSize = HookedKeys.Count;
            if (baseSize == 1)
            {
                var unistring = "1";
                for (int i = 0; i < value; i++)
                    unistring += "1";
                return unistring;
            }

            Stack<int> digits = new Stack<int>();
            string code = "";
            long tmp = value;
            while (tmp != 0)
            {
                digits.Push((int)(tmp % baseSize));
                tmp = (tmp - digits.Peek()) / baseSize;
            }

            foreach (var digit in digits)
                code += digit;

            var codeInt = Convert.ToInt32(code);
            return codeInt.ToString();
        }

        public void SaveSettings()
        {
            var userSettings = UserSettings.Instance;
            userSettings.HookedKeys = HookedKeys;
        }

        public void LoadSettings()
        {
            var userSettings = UserSettings.Instance;
            HookedKeys.Clear();
            HookedKeys.AddRange(userSettings.HookedKeys);
        }

        #endregion

        #region private methods

        private void SetCode(int number)
        {
            m_codeBuffer += number;
            FireCodeValueChanged(m_codeBuffer);
            m_codeTimer.Stop();
            m_codeTimer.Start();
        }

        #endregion

        #region event methods

        private void OnHookedKeyDown(object sender, KeyEventArgs e)
        {
            if (HookedKeys.Any() && HookedKeys.Contains(e.KeyCode))
                SetCode(HookedKeys.IndexOf(e.KeyCode));
        }

        private void OnCodeTimerTick(object sender, EventArgs e)
        {
            var code = m_codeBuffer;
            m_codeBuffer = string.Empty;
            m_codeTimer.Stop();
            FireCode(code);
        }

        #endregion

        #region firing events

        private void FireCode(string code)
        {
            CodeFired?.Invoke(this, new CodeEvent() { Code = code });
        }

        private void FireCodeValueChanged(string code)
        {
            CodeValueChanged?.Invoke(this, new CodeEvent() { Code = code });
        }

        #endregion
    }
}
