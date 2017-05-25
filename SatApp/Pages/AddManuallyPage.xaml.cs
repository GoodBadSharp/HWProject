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
    /// Логика взаимодействия для AddManuallyPage.xaml
    /// </summary>
    public partial class AddManuallyPage : Page
    {
        private Satellite _sat;
        DataContainer _data = new DataContainer();

        public DataContainer Data { get { return _data; } set { _data = value; } }

        public AddManuallyPage()
        {
            InitializeComponent();
        }

        private void inclinBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            inclinHint.Visibility = Visibility.Hidden;
        }

        private void inclinBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (inclinBox.Text == "")
            {
                inclinHint.Visibility = Visibility.Visible;
            }
        }

        private void eccenBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            eccenHint.Visibility = Visibility.Hidden;
        }

        private void eccenBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (eccenBox.Text == "")
            {
                eccenHint.Visibility = Visibility.Visible;
            }
        }

        private void raanBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            raanHint.Visibility = Visibility.Hidden;
        }

        private void raanBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (raanBox.Text == "")
            {
                raanHint.Visibility = Visibility.Visible;
            }
        }

        private void meanMotionBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            meanMotionHint.Visibility = Visibility.Hidden;
        }

        private void meanMotionBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (meanMotionBox.Text == "")
            {
                meanMotionHint.Visibility = Visibility.Visible;
            }
        }

        private void argBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            argHint.Visibility = Visibility.Hidden;
        }

        private void argBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (argBox.Text == "")
            {
                argHint.Visibility = Visibility.Visible;
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
           try
           {
                Orbit orbit = new Orbit(double.Parse(inclinBox.Text.Trim()), double.Parse(eccenBox.Text.Trim()),
                    double.Parse(raanBox.Text.Trim()), double.Parse(meanMotionBox.Text.Trim()), double.Parse(argBox.Text.Trim()));
                _sat = new Satellite(orbit, nameBox.Text.Trim(), int.Parse(idBox.Text.Trim()), int.Parse(yearBox.Text.Trim()));

                raanBox.Clear(); inclinBox.Clear(); eccenBox.Clear(); meanMotionBox.Clear(); argBox.Clear(); nameBox.Clear(); idBox.Clear(); yearBox.Clear();

                _data.Satellites.Add(_sat);
            MainWindow.AppWindow.RefreshList();
            } catch { MessageBox.Show("Не удалось добавить элемент. Проверьте формат введенных вами данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }
    }
}
