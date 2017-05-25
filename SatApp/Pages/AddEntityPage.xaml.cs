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
    /// Логика взаимодействия для AddEntityPage.xaml
    /// </summary>
    public partial class AddEntityPage : Page
    {
        public AddEntityPage()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonManualAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddManuallyPage);
        }
    }
}
