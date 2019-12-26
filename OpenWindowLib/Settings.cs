using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWindowLib
{
    /// <summary>
    /// Application wide settings
    /// </summary>
    public class Settings : ObservableObject
    {
        private bool _isMenuVisible = false;

        /// <summary>
        /// Gets or Sets the value for the top menu visibility (Default False)
        /// </summary>
        public bool IsMenuVisible
        {
            get { return _isMenuVisible; }
            set { _isMenuVisible = value; OnPropertyChanged("IsMenuVisible"); }
        }

        private string _outputPath = ".\\";

        /// <summary>
        /// Select the path for any files that are output by OpenWindow or its modules
        /// </summary>
        public string OutputPath
        {
            get { return _outputPath; }
            set { _outputPath = value; OnPropertyChanged("OutputPath"); }
        }


        /// <summary>
        /// Create a new instance of the settings class
        /// </summary>
        public Settings()
        {

        }

        /// <summary>
        /// Load settings from config file
        /// </summary>
        public void Load()
        {
            var settings = BinaryFormatedObject<Settings>.Restore("OpenWindow.config");

            if (settings == null)
                return;

            this.IsMenuVisible = settings.IsMenuVisible;
            this.OutputPath = settings.OutputPath;
        }
    }
}
