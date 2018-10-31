using SoundLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoundLauncher
{
    public class SoundLibrary
    {
        public bool IsEmpty => !Library.Any();

        public void ClearLibrary() => Library.Clear();

        public Dictionary<string, string> Library { get; private set; }

        public SoundLibrary()
        {
            Library = new Dictionary<string, string>();
        }

        public void Load(string filename, ErrorTracker errorTracker)
        {
            if (string.IsNullOrEmpty(filename))
                return;

            try
            {
                if (!File.Exists(filename))
                {
                    errorTracker.AddErrorMessage(string.Format(Resources.FileDoesNotExist, filename));
                    return;
                }

                ClearLibrary();

                using (var reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (!Library.ContainsKey(parts[0]))
                            Library.Add(parts[0], parts[1]);
                        else
                            errorTracker.AddErrorMessage(string.Format(Resources.DirectoryAllreadyContainsKey, parts[0]));
                    }
                }
            }
            catch (Exception ex)
            {
                errorTracker.AddErrorMessage(ex.Message);
            }
        }

        public void SaveLibraryToFile(string fileName)
        {
            using (var stream = new StreamWriter(fileName, false))
            {
                foreach (var entry in Library)
                {
                    stream.Write(entry.Key + ";" + entry.Value);
                    stream.WriteLine();
                }
                stream.Flush();
            }
        }
    }
}
