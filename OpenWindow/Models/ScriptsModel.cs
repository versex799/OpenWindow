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
        private int _numberOfArgs;

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfArgs
        {
            get { return _numberOfArgs; }
            set { _numberOfArgs = value; OnPropertyChanged("NumberOfArgs"); }
        }

        private string _scriptsLocation = ".\\Scripts\\";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptsLocation
        {
            get { return _scriptsLocation; }
            set { _scriptsLocation = value; OnPropertyChanged("ScriptsLocation"); }
        }

        private ObservableCollection<string> _scripts;

        public ObservableCollection<string> Scripts
        {   
            get { return _scripts; }
            set { _scripts = value; OnPropertyChanged("Scripts"); }
        }

        private FileSystemWatcher _fsw;

        public ScriptsModel()
        {
            Scripts = new ObservableCollection<string>();
            LoadScripts();
            WatchDirectory();
        }

        private void LoadScripts()
        {
            foreach(var file in Directory.GetFiles(ScriptsLocation))
            {
                if (!Scripts.Contains(file))
                    Scripts.Add(Path.GetFileName(file));
            }
        }

        private void WatchDirectory()
        {
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
    }
}
