using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


namespace SatApp
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        static string GetHash(string password)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            MD5 hasher = new MD5CryptoServiceProvider();
            string s = Encoding.Default.GetString(hasher.ComputeHash(passwordBytes));
            return s;
        }

        private void NavigateToMainWindow()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            
            new MainWindow().Show();
            currentWindow.Close();
        }

        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((loginBox.Text != "") && (passwordBox.Password != ""))
                {
                    Properties.Settings.Default.adminLogin = loginBox.Text;
                    Properties.Settings.Default.adminPassword = GetHash(passwordBox.Password);
                    Properties.Settings.Default.firstTimeLaunch = false;
                    Properties.Settings.Default.Save();
                    NavigateToMainWindow();
                }
                else
                {
                    MessageBox.Show("Неверный формат логина или пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            } catch { MessageBox.Show("Сбой при создании учетной записи", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.guestMode = true;
            NavigateToMainWindow();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((Properties.Settings.Default.adminLogin == loginBox.Text) && (Properties.Settings.Default.adminPassword == GetHash(passwordBox.Password)))
            {
                NavigateToMainWindow();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void loginBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (loginBox.Text == "")
            {
                Pages.LoginPage.loginBox.Background = new SolidColorBrush(Color.FromRgb(255, 200, 200));
            }
        }

        private void passwordBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (passwordBox.Password == "")
            {
                Pages.LoginPage.passwordBox.Background = new SolidColorBrush(Color.FromRgb(255, 200, 200));
            }
        }

        private void loginBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Pages.LoginPage.loginBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void passwordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Pages.LoginPage.passwordBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
