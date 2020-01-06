using OpenWindow.Commands;
using OpenWindow.ViewModels;
using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenWindow
{
    /// <summary>
    /// 
    /// </summary>
    public class AppViewModel : ObservableObject
    {
        /// <summary>
        /// Settings for the application
        /// </summary>
        public Settings AppSettings { get; set; }

        /// <summary>
        /// Switch the current view
        /// </summary>
        public RelayCommand SwitchViewCommand { get; set; }

        private object _currentViewModel;
        
        /// <summary>
        /// Contains the current view for the application
        /// </summary>
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set { OnPropertyChanged(ref _currentViewModel, value); }
        }

        private HomeViewModel _homeViewModel;

        /// <summary>
        /// View Model for the Home view
        /// </summary>
        public HomeViewModel HomeVm
        {
            get { return _homeViewModel; }
            set { OnPropertyChanged(ref _homeViewModel, value); }
        }

        private ModulesViewModel _modulesViewModel;

        /// <summary>
        /// View Model for the Modules View
        /// </summary>
        public ModulesViewModel ModuleVm
        {
            get { return _modulesViewModel; }
            set { OnPropertyChanged(ref _modulesViewModel, value); }
        }

        private ScriptsViewModel _scriptsViewModel;

        /// <summary>
        /// View Model for the Scripts view
        /// </summary>
        public ScriptsViewModel ScriptsVm
        {
            get { return _scriptsViewModel; }
            set {  OnPropertyChanged(ref _scriptsViewModel, value); }
        }

        private SettingsViewModel _settingsViewModel;

        /// <summary>
        /// View Model for the Settings view
        /// </summary>
        public SettingsViewModel SettingVm
        {
            get { return _settingsViewModel; }
            set { OnPropertyChanged(ref _settingsViewModel, value); }
        }

        /// <summary>
        /// Initialize an instance of the AppViewModel
        /// </summary>
        public AppViewModel()
        {
            AppSettings = new Settings();
            AppSettings.Load();

            ModuleVm = new ModulesViewModel();
            HomeVm = new HomeViewModel();
            SettingVm = new SettingsViewModel(AppSettings);
            ScriptsVm = new ScriptsViewModel();
            
            CurrentViewModel = HomeVm;

            SwitchViewCommand = new RelayCommand(ChangeView);
        }

        /// <summary>
        /// Relay Command for changing the current view
        /// </summary>
        public void ChangeView(string view)
        {
            switch(view)
            {
                case "settings":
                    {
                        CurrentViewModel = SettingVm;
                        break;
                    }
                case "modules":
                    {
                        CurrentViewModel = ModuleVm;
                        break;
                    }
                case "home":
                    {
                        CurrentViewModel = HomeVm;
                        break;
                    }
                case "scripts":
                    {
                        CurrentViewModel = ScriptsVm;
                        break;
                    }
            }
        }
    }
}
