using OpenWindow.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand NavigateToCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HomeViewModel()
        {
            NavigateToCommand = new RelayCommand(NavigateTo);
        }

        private void NavigateTo(string url)
        {
            Process.Start(new ProcessStartInfo(url));
        }
    }
}
