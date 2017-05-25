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
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using Zeptomoby.OrbitTools;

namespace SatApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        private DataContainer _data = new DataContainer();
        public DataContainer Data { get { return _data; } set { _data = value; } }
        public static MainWindow AppWindow;

        public void AddInstance (Satellite sat)
        {
            _data.Satellites.Add(sat);
        }

        public void RefreshList()
        {
            Pages.ViewDataPage.listBox.ItemsSource = null;
            Pages.ViewDataPage.listBox.ItemsSource = Pages.AddManuallyPage.Data.Satellites;
        }

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;

            mainFrame.Navigate(new ViewDataPage());
            if (Properties.Settings.Default.guestMode)
            {
                buttonAdd.IsEnabled = false; 
            }
        }

        //~MainWindow()
        //{
        //    if (Pages.AddManuallyPage.Data.Satellites.Count != 0)
        //        using (var stream = new FileStream("SatellitesData.xml", FileMode.Create))
        //        {
        //            XmlSerializer xml = new XmlSerializer(typeof(DataContainer));
        //            xml.Serialize(stream, Pages.AddManuallyPage.Data.Satellites);
        //        }
        //}

        private void windowMouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(Pages.AddEntityPage);
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(Pages.ViewDataPage);
        }
    }
}
