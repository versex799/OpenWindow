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
