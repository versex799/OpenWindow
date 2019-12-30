using OpenWindow.MEF;
using OpenWindow.ViewModels;
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

namespace OpenWindow.Views
{
    /// <summary>
    /// Interaction logic for Modules.xaml
    /// </summary>
    public partial class ModulesView
    {
        /// <summary>
        /// View model for the Modules view
        /// </summary>
        public ModulesViewModel _viewmodel;

        /// <summary>
        /// Creates an instance of the module
        /// </summary>
        public ModulesView()
        {
            InitializeComponent();
            _viewmodel = new ModulesViewModel();
            DataContext = _viewmodel;
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
