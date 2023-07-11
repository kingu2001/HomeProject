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
using System.Windows.Shapes;

namespace ATM_Software.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        HomepageWindow hpw; 
        public LoginWindow()
        {
            InitializeComponent();
            hpw = new HomepageWindow();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            hpw.Show();
            Close(); 
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
