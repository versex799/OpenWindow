﻿using OpenWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for ScriptsView.xaml
    /// </summary>
    public partial class ScriptsView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ScriptsViewModel ViewModel { get; set; }

        /// <summary>
        /// Initialize an instance of ScriptsView
        /// </summary>
        public ScriptsView()
        {
            InitializeComponent();
            ViewModel = new ScriptsViewModel();
            DataContext = ViewModel;
        }
    }
}
