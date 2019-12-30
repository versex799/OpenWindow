using OpenWindow.MEF;
using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWindow.Models
{
    /// <summary>
    /// Model for the Modules view
    /// </summary>
    public class ModulesModel : ObservableObject
    {
        /// <summary>
        /// Importer for MEF modules
        /// </summary>
        public Importer Importer { get; set; }

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
                    _selectedModule = value;
                    OnPropertyChanged("SelectedModule");
                }
            }
        }

        /// <summary>
        /// Conduct importation of modules
        /// </summary>
        public void ImportModules()
        {
            if (Importer == null)
            {
                Importer = new Importer();
                Importer.Import();
            }
        }
    }
}
