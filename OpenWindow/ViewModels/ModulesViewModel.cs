using OpenWindow.Commands;
using OpenWindow.MEF;
using OpenWindow.Models;
using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ModulesViewModel : ObservableObject
    {
        public event Output ForwardToOutput;

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand RunModuleCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand OpenModuleCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Lazy<ModuleUserControl, IModuleMetadata>> Modules
        {
            get { return Model.Importer.Modules; }
        }

        private Lazy<ModuleUserControl, IModuleMetadata> _selectedModule;

        /// <summary>
        /// Cache the selected module
        /// </summary>
        public Lazy<ModuleUserControl, IModuleMetadata> SelectedModule
        {
            get
            {
                return _selectedModule;
            }
            set
            {
                if (value != _selectedModule)
                {
                    OnPropertyChanged(ref _selectedModule, value);
                    CurrentControl = new UserControlMetaDataViewModel(value.Metadata);
                }
            }
        }

        private UserControlMetaDataViewModel _userControlMetaDataViewModel;

        /// <summary>
        /// 
        /// </summary>
        public UserControlMetaDataViewModel UserControlMetaDataVm
        {
            get { return _userControlMetaDataViewModel; }
            set { OnPropertyChanged(ref _userControlMetaDataViewModel, value); }
        }

        private object _currentControl;

        /// <summary>
        /// 
        /// </summary>
        public object CurrentControl
        {
            get { return _currentControl; }
            set { OnPropertyChanged(ref _currentControl, value); }
        }

        /// <summary>
        /// Model for the Modules view
        /// </summary>
        public ModulesModel Model { get; set; }

        /// <summary>
        /// Initiate an instance of ModulesViewModel
        /// </summary>
        public ModulesViewModel()
        {
            Model = new ModulesModel();
            Model.ImportModules();


            OpenModuleCommand = new RelayCommand(OpenModule);
            RunModuleCommand = new RelayCommand(Run, CanRun);
        }

        private void Run(string arg)
        {
            SelectedModule.Value.Run();
        }

        private bool CanRun(object arg)
        {
            if (CurrentControl != null && CurrentControl is ModuleUserControl)
                return true;
            return false;
        }

        private void OpenModule(string arg)
        {
            if (SelectedModule == null)
                return;

            CurrentControl = SelectedModule.Value;
            SelectedModule.Value.SendToOutput += ((message) => ForwardToOutput?.Invoke(message));
        }

    }
}
