using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWindow.Models
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
        public bool IsMenuVisisble
        {
            get { return _isMenuVisible; }
            set { _isMenuVisible = value; OnProprtyChanged("IsMenuVisible"); }
        }

        /// <summary>
        /// Create a new instance of the settings class
        /// </summary>
        public Settings()
        {

        }
    }
}
