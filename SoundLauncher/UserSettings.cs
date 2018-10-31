using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SoundLauncher
{
    public class UserSettings : IEquatable<UserSettings>
    {
        #region enum

        private enum XmlElementName
        {
            SoundLauncher,
            UserSettings,
            ActualLibraryFilePath,
            ClickToPlay,
            SoundManager,
            SelectedDevices,
            Device,
            Volume,
            KeyManager,
            SelectedHookedKeys,
            Key,
        }

        #endregion

        #region singelton handling

        private static UserSettings m_instance;

        private static UserSettings m_lastSave;

        public static UserSettings Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new UserSettings();
                    m_instance.Load();
                    m_lastSave = (UserSettings)m_instance.MemberwiseClone();
                }
                return m_instance;
            }
        }

        private UserSettings() { }

        #endregion

        #region user path handling

        private string m_configFileName = @"SoundLauncher.slc";

        private string m_folderName = @"SoundLauncher";

        private string GetUserFilePath()
        {
            var userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var folderpath = Path.Combine(userpath, m_folderName);
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            return Path.Combine(folderpath, m_configFileName);
        }

        #endregion

        #region UserSettings properties

        public string ActualLibraryFilePath { get; set; }
        public bool ClickToPlay { get; set; }
        public float Volume { get; set; }
        public IList<int> SelectedAudioDevices { get; set; }
        public IList<Keys> HookedKeys { get; set; }

        #endregion

        #region methods

        public void Save()
        {
            // only save if settings have changed
            if (Equals(m_lastSave))
                return;

            XDocument xdoc = new XDocument();
            var rootElement = new XElement(XmlElementName.SoundLauncher.ToString());

            // Gui
            var settingsElement = new XElement(XmlElementName.UserSettings.ToString());
            settingsElement.Add(new XElement(XmlElementName.ActualLibraryFilePath.ToString(), ActualLibraryFilePath));
            settingsElement.Add(new XElement(XmlElementName.ClickToPlay.ToString(), ClickToPlay));
            rootElement.Add(settingsElement);

            // Sound Manager
            var soundManagerElement = new XElement(XmlElementName.SoundManager.ToString());
            var selectedDevicesElement = new XElement(XmlElementName.SelectedDevices.ToString());
            foreach (var device in SelectedAudioDevices)
                selectedDevicesElement.Add(new XElement(XmlElementName.Device.ToString(), device));
            soundManagerElement.Add(selectedDevicesElement);
            soundManagerElement.Add(new XElement(XmlElementName.Volume.ToString(), Volume));
            rootElement.Add(soundManagerElement);

            // Key Manager
            var keyManagerElement = new XElement(XmlElementName.KeyManager.ToString());
            var selectedHookedKeysElement = new XElement(XmlElementName.SelectedHookedKeys.ToString());
            foreach (var key in HookedKeys)
                selectedHookedKeysElement.Add(new XElement(XmlElementName.Key.ToString(), key));
            keyManagerElement.Add(selectedHookedKeysElement);
            rootElement.Add(keyManagerElement);

            // write xml
            xdoc.Add(rootElement);
            xdoc.Save(GetUserFilePath());
        }

        private void Load()
        {
            if (File.Exists(GetUserFilePath()))
            {
                // read xml
                var xdoc = XDocument.Load(GetUserFilePath());
                var rootElement = xdoc.Root;

                // Gui
                var settingsElement = rootElement.Element(XmlElementName.UserSettings.ToString());
                if (settingsElement != null)
                {
                    var actualLibraryFilePathElement = settingsElement.Element(XmlElementName.ActualLibraryFilePath.ToString());
                    if (actualLibraryFilePathElement != null && actualLibraryFilePathElement.Value != null)
                        ActualLibraryFilePath = actualLibraryFilePathElement.Value;

                    var clickToPlayElement = settingsElement.Element(XmlElementName.ClickToPlay.ToString());
                    if (clickToPlayElement != null && clickToPlayElement.Value != null)
                        ClickToPlay = Convert.ToBoolean(clickToPlayElement.Value);
                }

                // Sound Manager
                var soundManagerElement = rootElement.Element(XmlElementName.SoundManager.ToString());
                if (soundManagerElement != null)
                {
                    var selectedDevicesElement = soundManagerElement.Element(XmlElementName.SelectedDevices.ToString());
                    if (selectedDevicesElement != null)
                    {
                        SelectedAudioDevices = new List<int>();
                        foreach (var deviceElement in selectedDevicesElement.Elements(XmlElementName.Device.ToString()))
                            if (deviceElement != null && deviceElement.Value != null)
                                SelectedAudioDevices.Add(Convert.ToInt32(deviceElement.Value));
                    }
                    var volumeElement = soundManagerElement.Element(XmlElementName.Volume.ToString());
                    if (volumeElement != null && volumeElement.Value != null)
                        Volume = float.Parse(volumeElement.Value, CultureInfo.InvariantCulture.NumberFormat);
                }

                // Key Manager
                var keyManagerElement = rootElement.Element(XmlElementName.KeyManager.ToString());
                if (keyManagerElement != null)
                {
                    var hookedKeysElement = keyManagerElement.Element(XmlElementName.SelectedHookedKeys.ToString());
                    var converter = new KeysConverter();
                    if (hookedKeysElement != null)
                    {
                        HookedKeys = new List<Keys>();
                        foreach (var keyElement in hookedKeysElement.Elements(XmlElementName.Key.ToString()))
                            if (keyElement != null && keyElement.Value != null)
                                HookedKeys.Add((Keys)converter.ConvertFromString(keyElement.Value));
                    }
                }
            }
        }

        public bool Equals(UserSettings other)
        {
            return ActualLibraryFilePath == other.ActualLibraryFilePath &&
                ClickToPlay == other.ClickToPlay &&
                Volume == other.Volume &&
                SelectedAudioDevices.SequenceEqual(other.SelectedAudioDevices) &&
                HookedKeys.SequenceEqual(other.HookedKeys);
        }

        #endregion
    }
}
