using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace OpenWindowLib
{
    public delegate void Output(string message);

    public abstract partial class ModuleUserControl : UserControl
    {
        /// <summary>
        /// Send information back to the main application.
        /// </summary>
        public virtual event Output SendToOutput;

        /// <summary>
        /// Settings from the application.
        /// </summary>
        public Settings AppSettings { get; set; }

        /// <summary>
        /// Create a new instance of your user control.
        /// </summary>
        public ModuleUserControl()
        {
            
        }

        /// <summary>
        /// Initialization code for your module goes here.
        /// </summary>
        public virtual void Initialize(Settings settings)
        {
            AppSettings = settings;
        }

        /// <summary>
        /// Cleanup code for your module goes here.
        /// </summary>
        public virtual void Destroy()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Abort any operations currently in progress.
        /// </summary>
        public abstract void Abort();

        public abstract void Input(string input);
    }
}
