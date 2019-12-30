using OpenWindow.Models;
using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ModulesViewModel : ObservableObject
    {
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
        }

    }
}
