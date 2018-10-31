using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundLauncher
{
    public class SoundManager
    {
        #region members

        private List<WaveOut> m_currentPlayingWaveOuts;

        private SoundLibrary m_soundLibrary;

        #endregion

        #region properties

        public List<int> SelectedAudioDevices { get; }

        public Dictionary<string, string> Library => m_soundLibrary.Library;

        public bool HasSounds => !m_soundLibrary.IsEmpty;

        public bool IsPlaying => m_currentPlayingWaveOuts.Any();

        public void ClearLibrary() => m_soundLibrary.ClearLibrary();

        public void LoadLibrary(string fileName, ErrorTracker errorTracker) => m_soundLibrary.Load(fileName, errorTracker);

        public void SaveLibraryToFile(string filename) => m_soundLibrary.SaveLibraryToFile(filename);

        public float Volume { get; set; }

        public EventHandler<bool> PlayingChanged;

        #endregion

        #region ctor

        public SoundManager()
        {
            m_currentPlayingWaveOuts = new List<WaveOut>();
            m_soundLibrary = new SoundLibrary();
            SelectedAudioDevices = new List<int>();
            Volume = 1;
        }

        #endregion

        #region methods

        public void StopAllCurrentPlaying()
        {
            foreach (var waveout in m_currentPlayingWaveOuts)
                if (waveout != null)
                    waveout.Stop();
        }

        private void PlaySound(string file, ErrorTracker errorTracker)
        {
            void playOnDevice(int device)
            {
                try
                {
                    var mp3reader = new Mp3FileReader(file);
                    var waveOut = new WaveOut();
                    waveOut.DeviceNumber = device;
                    waveOut.Volume = Volume;
                    waveOut.Init(mp3reader);
                    m_currentPlayingWaveOuts.Add(waveOut);
                    waveOut.PlaybackStopped += waveOut_PlaybackStopped;
                    waveOut.Play();
                    FirePlaybackStatusChanged(true);
                }
                catch (Exception ex)
                {
                    errorTracker.AddErrorMessage(file + ": " + ex.Message);
                }
            }

            foreach (var device in SelectedAudioDevices)
                playOnDevice(device);
        }

        public void ProcessCode(string text, ErrorTracker errorTracker)
        {
            if (text == @"0")
            {
                StopAllCurrentPlaying();
                FirePlaybackStatusChanged(false);
                return;
            }
            string file;
            if (Library.TryGetValue(text, out file))
            {
                PlaySound(file, errorTracker);
            }
            else if (!IsPlaying)
                FirePlaybackStatusChanged(false);
            else
                FirePlaybackStatusChanged(true);
        }

        public void SaveSettings()
        {
            var userSettings = UserSettings.Instance;
            userSettings.SelectedAudioDevices = SelectedAudioDevices;
            userSettings.Volume = Volume;
        }

        public void LoadSettings()
        {
            var userSettings = UserSettings.Instance;
            SelectedAudioDevices.Clear();
            SelectedAudioDevices.AddRange(userSettings.SelectedAudioDevices);
            Volume = userSettings.Volume;
        }

        #endregion

        #region event methods

        private void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            m_currentPlayingWaveOuts.Remove((WaveOut)sender);
            if (!m_currentPlayingWaveOuts.Any())
                FirePlaybackStatusChanged(false);
        }

        private void FirePlaybackStatusChanged(bool isPlaying)
        {
            PlayingChanged?.Invoke(this, isPlaying);
        }

        #endregion
    }
}
