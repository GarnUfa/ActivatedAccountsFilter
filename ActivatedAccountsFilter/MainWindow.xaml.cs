﻿using System.Collections.ObjectModel;
using System.Windows;
using ActivatedAccountsFilter.Model;
using ActivatedAccountsFilter.ViewModel;

namespace ActivatedAccountsFilter
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }
    }
}
