using FlagsTest.WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FlagsTest.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public UserControl CurrentContent { get; set; }

        private bool _appBusy;
        public bool AppBusy
        {
            get { return _appBusy; }
            set
            {
                _appBusy = value;
                NotifyPropertyChanged();
            }
        }

        private bool _appNotBusy;
        public bool AppNotBusy
        {
            get { return !_appNotBusy; }
           
        }


        private DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get { return _currentDateTime; }
            private set
            {
                _currentDateTime = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindowViewModel() {
  
            CurrentContent = new MoviesView();
            // CurrentContent = new SpoonacularView();
            //CurrentContent = new TheRundownView();

            _currentDateTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }



        void timer_Tick(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now;
        }

        
    }
}
