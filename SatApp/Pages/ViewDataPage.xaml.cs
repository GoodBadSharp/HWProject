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
    /// Логика взаимодействия для ViewDataPage.xaml
    /// </summary>
    public partial class ViewDataPage : Page
    {

        public ViewDataPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.guestMode)
            {
                buttonDelete.IsEnabled = false;
                buttonEdit.IsEnabled = false;
            }

            //searchCriteriaComboBox.Items.Add("по названию");
            //searchCriteriaComboBox.Items.Add("по году запуска");
            //searchCriteriaComboBox.Items.Add("по NORAD ID");

            if (listBox.Items.IsEmpty)
            {
                listEmptyNotifyBlock.Visibility = Visibility.Visible;
            }
            else
            {
                listEmptyNotifyBlock.Visibility = Visibility.Hidden;
            }
        }

        private void searchBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            searchHint.Visibility = Visibility.Hidden;
        }

        private void searchBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchHint.Visibility = Visibility.Visible;
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Pages.AddManuallyPage.Data.Satellites.RemoveAt(listBox.SelectedIndex);
                MainWindow.AppWindow.RefreshList();
            }
        }

    }
}
