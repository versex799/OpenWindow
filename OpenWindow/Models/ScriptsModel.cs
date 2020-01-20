using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenWindow.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ScriptsModel : ObservableObject
    {
        private string _scriptsLocation = ".\\Scripts\\";

        /// <summary>
        /// The location of the Scripts directory
        /// </summary>
        public string ScriptsLocation
        {
            get { return _scriptsLocation; }
            set { OnPropertyChanged(ref _scriptsLocation, value); }
        }

        private string _selectedScript;

        /// <summary>
        /// The currently selected script
        /// </summary>
        public string SelectedScript
        {
            get { return _selectedScript; }
            set { OnPropertyChanged(ref _selectedScript, value); InitializePython(); }
        }

        private ObservableCollection<string> _scripts;

        /// <summary>
        /// A collection of available scripts
        /// </summary>
        public ObservableCollection<string> Scripts
        {   
            get { return _scripts; }
            set { OnPropertyChanged(ref _scripts, value); }
        }

        private FileSystemWatcher _fsw;

        /// <summary>
        /// Initialize an instance of ScriptsModel
        /// </summary>
        public ScriptsModel()
        {
            Scripts = new ObservableCollection<string>();
            LoadScripts();
            WatchDirectory();
        }

        private void LoadScripts()
        {
            if (!Directory.Exists(ScriptsLocation))
                return;

            foreach(var file in Directory.GetFiles(ScriptsLocation))
            {
                if (!Scripts.Contains(file))
                    Scripts.Add(Path.GetFileName(file));
            }
        }

        private void WatchDirectory()
        {
            if (!Directory.Exists(ScriptsLocation))
            {
                Directory.CreateDirectory(ScriptsLocation);
                return;
            }

            _fsw = new FileSystemWatcher(ScriptsLocation);
            _fsw.Created += _fsw_Created;
            _fsw.Deleted += _fsw_Deleted;
            _fsw.Renamed += _fsw_Renamed;
            _fsw.EnableRaisingEvents = true;
        }

        private void _fsw_Renamed(object sender, RenamedEventArgs e)
        {
            if(Scripts.Contains(e.OldName))
            {
                Application.Current.Dispatcher.Invoke(() => {
                    Scripts.Remove(e.OldName);
                    Scripts.Add(e.Name);
                });
            }
        }

        private void _fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            if(Scripts.Contains(e.Name))
            {
                Application.Current.Dispatcher.Invoke(() => {
                    Scripts.Remove(e.Name);
                });
            }
        }

        private void _fsw_Created(object sender, FileSystemEventArgs e)
        {
            if (!Scripts.Contains(e.Name) && e.Name.ToUpper().EndsWith(".PY"))
            {
                Application.Current.Dispatcher.Invoke(() => {
                    Scripts.Add(e.Name);
                });
            }
        }

        private void InitializePython()
        {
            if (string.IsNullOrEmpty(SelectedScript))
                return;

            var engine = IronPython.Hosting.Python.CreateEngine();
            var script = ScriptsLocation + SelectedScript;

            var source = engine.CreateScriptSourceFromFile(script);
            var eIO = engine.Runtime.IO;
            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);
            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);
            var scope = engine.CreateScope();
            source.Execute(scope);

            IronPython.Runtime.List vars = scope.GetVariable("arguments");

            foreach(var arg in vars)
            {
                MessageBox.Show(arg.ToString());
            }
        }
    }
}
