﻿using System;
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

namespace индивид
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _admin = false;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new avtoriza());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {


            if (MainFrame.CanGoBack)

            {
                Back.Visibility = Visibility.Visible;
            }
            else
            {
                Back.Visibility = Visibility.Collapsed;
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}
