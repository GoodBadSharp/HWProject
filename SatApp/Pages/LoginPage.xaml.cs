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
            if (!Properties.Settings.Default.firstTimeLaunch)
            {
                buttonSignup.Visibility = Visibility.Hidden;
                buttonCancel.Visibility = Visibility.Hidden;
            }
        }

        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.HomePage);
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.HomePage);
        }


        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.HomePage);
        }

        private void passwordBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (passwordBox.Password == "")
            {
                passwordBox.Background = new SolidColorBrush(Color.FromRgb(255, 190, 190));
            }
        }

        private void loginBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (loginBox.Text == "")
            {
                loginBox.Background = new SolidColorBrush(Color.FromRgb(255, 190, 190));
            }
        }

        private void passwordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            passwordBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void loginBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            loginBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LoginPage_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (buttonSignup.Visibility == Visibility.Visible))
                buttonSignup_Click(null, null);
            else if ((e.Key == Key.Enter) && (buttonLogin.Visibility == Visibility.Visible))
                buttonLogin_Click(null, null);
        }

    }
}
