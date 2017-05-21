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
    /// Логика взаимодействия для FirstLoginPage.xaml
    /// </summary>
    public partial class FirstLoginPage : Page
    {
        public FirstLoginPage()
        {
            InitializeComponent();
        }
        
        private void buttonSkipSignup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.HomePage);
        }

        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
            Pages.LoginPage.buttonGuest.Visibility = Visibility.Hidden;
            Pages.LoginPage.buttonLogin.Visibility = Visibility.Hidden;
        }
    }
}
