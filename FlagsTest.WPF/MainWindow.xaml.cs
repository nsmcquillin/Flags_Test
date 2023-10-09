using FlagsTest.LIBRARY.APIHelpers;
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

namespace FlagsTest.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; }
        }


        //public void  Application_Busy(string busyMessage)
        //{
        //    gridBusyIndicator.Visibility = Visibility.Visible;
        //}

        //public void Application_NotBusy(string busyMessage)
        //{
        //    gridBusyIndicator.Visibility = Visibility.Collapsed;
        //}





    }
}
