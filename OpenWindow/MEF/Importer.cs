using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenWindow.MEF
{
    /// <summary>
    /// Import MEF Components
    /// </summary>
    public class Importer
    {
        [ImportMany(typeof(ModuleUserControl))]
        private IEnumerable<Lazy<ModuleUserControl, IModuleMetadata>> _modules;

        /// <summary>
        /// List all available modules in alphabetical order
        /// </summary>
        public List<Lazy<ModuleUserControl, IModuleMetadata>> Modules { get
            {
                return _modules.OrderBy(m => m.Metadata.Name).ToList();
            }
        }

        /// <summary>
        /// Import modules.
        /// </summary>
        public void Import()
        {
            var catelog = new AggregateCatalog();
            catelog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            CompositionContainer container = new CompositionContainer(catelog);
            container.ComposeParts(this);
        }

        /// <summary>
        /// Get a list of available modules.
        /// </summary>
        /// <returns></returns>
        public List<string> GetModuleNames()
        {
            List<string> names = new List<string>();

            foreach(var mod in Modules)
            {
                names.Add(mod.Metadata.Name);
            }

            return names;
        }

        /// <summary>
        /// Get metadata for the specified module.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IModuleMetadata GetModuleMetadata(string name)
        {
            return _modules.Where(m => m.Metadata.Name == name)?.FirstOrDefault()?.Metadata ?? null;
        }

        /// <summary>
        /// Get the specified module
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleUserControl GetModule(string name)
        {
            return _modules.Where(m => m.Metadata.Name == name)?.FirstOrDefault().Value ?? null;
        }
    }
}
