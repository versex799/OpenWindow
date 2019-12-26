using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OpenWindowLib
{
    /// <summary>
    /// Notify UI of changes to properties
    /// </summary>
    [Serializable]
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Notify UI of changes to properties
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify UI of changes to the specified property
        /// </summary>
        /// <param name="property"></param>
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
