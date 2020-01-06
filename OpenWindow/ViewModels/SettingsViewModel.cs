using OpenWindow.Commands;
using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SettingsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand SaveSettingsCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SettingsViewModel(Settings settings)
        {
            Settings = settings;
            SaveSettingsCommand = new RelayCommand(Save);
        }

        private void Save(string arg)
        {
            Settings.Save();
            MessageBox.Show("Settings saved", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
