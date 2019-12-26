using OpenWindow.MEF;
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
        Importer _importer;

        /// <summary>
        /// Creates an instance of the module
        /// </summary>
        public ModulesView()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listview1.SelectedIndex > -1)
                contentControl1.Content = _importer.GetModule(listview1.SelectedItem.ToString());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_importer == null)
            {
                _importer = new Importer();
                _importer.Import();
                listview1.ItemsSource = _importer.GetModuleNames();
            } 
        }
    }
}
