using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleModule
{
    /// <summary>
    /// Interaction logic for Modules.xaml
    /// </summary>
    [Export(typeof(ModuleUserControl))]
    [ExportMetadata("Name", "Example Module")]
    [ExportMetadata("Description", "This is a simple example module intended to demonstrate the extensibility of Open Window.")]
    [ExportMetadata("ModuleVersion", "1.2.0.0")]
    [ExportMetadata("OpenWindowVersion", "1.0.0.0")]
    [ExportMetadata("TargetOS", OSType.Linux)]
    [ExportMetadata("ModType", ModuleType.Exploit)]
    [ExportMetadata("Bit", BitType.Bit64)]
    public partial class ExampleModule : ModuleUserControl
    {
        public override event Output SendToOutput;

        /// <summary>
        /// Creates an instance of the module
        /// </summary>
        public ExampleModule() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Intializes settings required for proper operation of the module
        /// </summary>
        public override void Initialize(Settings settings)
        {
            base.Initialize(settings);
        }

        /// <summary>
        /// Activates the modules operations
        /// </summary>
        public override void Run()
        {
            SendToOutput?.Invoke("I am running!");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Abort()
        {

        }
    }
}
