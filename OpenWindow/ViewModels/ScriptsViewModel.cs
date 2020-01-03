using OpenWindow.Models;
using System;
using System.Collections.Generic;
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
        public ScriptsModel Model { get; set; }

        public ScriptsViewModel()
        {
            Model = new ScriptsModel();
        }
    }
}
