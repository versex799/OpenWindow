using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace OpenWindowLib
{
    /// <summary>
    /// Application wide settings
    /// </summary>
    [Serializable]
    public class Settings : ObservableObject
    {
        private bool _isMenuVisible = false;

        /// <summary>
        /// Gets or Sets the value for the top menu visibility (Default False)
        /// </summary>
        public bool IsMenuVisible
        {
            get { return _isMenuVisible; }
            set { OnPropertyChanged(ref _isMenuVisible, value); MenuVisibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        private string _outputPath = ".\\";

        /// <summary>
        /// Select the path for any files that are output by OpenWindow or its modules
        /// </summary>
        public string OutputPath
        {
            get { return _outputPath; }
            set { _outputPath = value; OnPropertyChanged(ref _outputPath, value); }
        }

        private Visibility _menuVisibilty;

        /// <summary>
        /// Sets the visibility of the top menu bar
        /// </summary>
        public Visibility MenuVisibility
        {
            get { return _menuVisibilty; }
            set { OnPropertyChanged(ref _menuVisibilty, value); }
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

        public void Save()
        {
            BinaryFormatedObject<Settings>.Save(this, "OpenWindow.Config");
        }
    }
}
