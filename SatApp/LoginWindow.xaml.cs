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

namespace SatApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            if ((Properties.Settings.Default.firstTimeLaunch || !Properties.Settings.Default.firstTimeLaunch) && 
                Properties.Settings.Default.adminPassword == "" && Properties.Settings.Default.adminLogin == "")
            {
                loginFrame.Navigate(new FirstLoginPage());
            }
            else if (!Properties.Settings.Default.firstTimeLaunch && Properties.Settings.Default.skipSignupPersist)
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                loginFrame.Navigate(new LoginPage());
                Pages.LoginPage.buttonSignup.Visibility = Visibility.Hidden;
                Pages.LoginPage.buttonCancel.Visibility = Visibility.Hidden;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
    }
}
