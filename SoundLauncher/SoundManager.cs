using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundLauncher
{
    public class SoundManager
    {
        #region members

        private Dictionary<int, WaveOut> m_currentPlayingWaveOuts;

        private Dictionary<int, string> m_soundIdtoCodeMapping;

        private List<int> m_endlessLoops;

        private SoundLibrary m_soundLibrary;

        private int m_currentPlayingId;

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

        public List<int> CurrentlyPlayingSounds => m_currentPlayingWaveOuts.Keys.ToList();

        #endregion

        #region event handlers

        public EventHandler<bool> PlayingChanged;

        public EventHandler<List<int>> CurrentlyPlayingSoundsChanged;

        #endregion

        #region ctor

        public SoundManager()
        {
            m_currentPlayingWaveOuts = new Dictionary<int, WaveOut>();
            m_soundIdtoCodeMapping = new Dictionary<int, string>();
            m_endlessLoops = new List<int>();
            m_currentPlayingId = 0;
            m_soundLibrary = new SoundLibrary();
            SelectedAudioDevices = new List<int>();
            Volume = 1;
        }

        #endregion

        #region methods

        public void StopAllCurrentPlaying()
        {
            foreach (var waveout in m_currentPlayingWaveOuts.Values)
                if (waveout != null)
                    waveout.Stop();
            m_endlessLoops.Clear();
        }

        public void StopSound(int id)
        {
            WaveOut waveout;
            if (m_currentPlayingWaveOuts.TryGetValue(id, out waveout))
                if (waveout != null)
                    waveout.Stop();
        }

        public void PlayCode(string code, bool endlessLoop, ErrorTracker errorTracker)
        {
            if (code == @"0")
            {
                StopAllCurrentPlaying();
                FirePlaybackStatusChanged(false);
                return;
            }
            string file;
            if (Library.TryGetValue(code, out file))
            {
                PlaySound(code, file, endlessLoop, errorTracker);
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
            foreach (var device in userSettings.SelectedAudioDevices)
                if(device < WaveOut.DeviceCount)
                    SelectedAudioDevices.Add(device);

            Volume = userSettings.Volume;
        }

        public string GetCodeForId(int id)
        {
            string res;
            m_soundIdtoCodeMapping.TryGetValue(id, out res);
            return res;
        }

        public string GetFileNameForId(int id)
        {
            string res, fileName;
            if (m_soundIdtoCodeMapping.TryGetValue(id, out res))
                if (Library.TryGetValue(res, out fileName))
                    return fileName;
            return null;
        }

        public bool IsEndlessLoop(int id)
        {
            return m_endlessLoops.Contains(id);
        }

        private void PlaySound(string code, string file, bool endlessLoop, ErrorTracker errorTracker)
        {
            void playOnDevice(int device)
            {
                try
                {

                    var mp3reader = new Mp3FileReader(file);
                    var waveOut = new WaveOut();
                    waveOut.DeviceNumber = device;
                    waveOut.Volume = Volume;

                    if (endlessLoop)
                        waveOut.Init(new LoopStream(mp3reader));
                    else
                        waveOut.Init(mp3reader);

                    AddWaveOut(code, waveOut, endlessLoop);
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

        private void AddWaveOut(string code, WaveOut waveout, bool endlessLoop)
        {
            var id = m_currentPlayingId++;
            m_soundIdtoCodeMapping.Add(id, code);
            m_currentPlayingWaveOuts.Add(id, waveout);
            if (endlessLoop)
                m_endlessLoops.Add(id);
            FireCurrentlyPlayingSoundsChanged();
        }

        private void RemoveWaveOut(WaveOut waveout)
        {
            var id = m_currentPlayingWaveOuts.First(x => x.Value == waveout).Key;
            m_currentPlayingWaveOuts.Remove(id);
            m_soundIdtoCodeMapping.Remove(id);
            m_endlessLoops.Remove(id);
            FireCurrentlyPlayingSoundsChanged();
        }

        #endregion

        #region event methods

        private void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            var waveout = (WaveOut)sender;
            RemoveWaveOut(waveout);
            waveout.Dispose();

            if (!IsPlaying)
                FirePlaybackStatusChanged(false);
        }

        private void FirePlaybackStatusChanged(bool isPlaying)
        {
            PlayingChanged?.Invoke(this, isPlaying);
        }

        private void FireCurrentlyPlayingSoundsChanged()
        {
            CurrentlyPlayingSoundsChanged?.Invoke(this, CurrentlyPlayingSounds);
        }

        #endregion
    }
}
