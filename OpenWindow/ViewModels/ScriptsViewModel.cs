using OpenWindow.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ScriptsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ScriptsModel Model { get; set; }

        /// <summary>
        /// Initialize an instance of ScriptsViewModel
        /// </summary>
        public ScriptsViewModel()
        {
            Model = new ScriptsModel();
            
        }


    }
}
