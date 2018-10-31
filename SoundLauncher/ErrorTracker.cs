using System;

namespace SoundLauncher
{
    public class ErrorTracker
    {
        public string ErrorMessage { get; private set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public bool HasNewError { get; set; }

        public EventHandler<string> NewError;

        public void AddErrorMessage(string message)
        {
            ErrorMessage += message + Environment.NewLine;
            HasNewError = true;
            NewError?.Invoke(this, message);
        }
    }
}
