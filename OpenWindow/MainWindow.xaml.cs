using OpenWindow.ViewModels;
using System;
using System.Collections.Generic;
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

namespace OpenWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new HomeViewModel();
        }

        private void HomeBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void SettingsBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SettingsViewModel();
        }

        private void ModulesBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ModulesViewModel();
        }
    }
}
