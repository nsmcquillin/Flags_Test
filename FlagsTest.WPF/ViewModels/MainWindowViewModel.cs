using FlagsTest.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlagsTest.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public UserControl CurrentContent { get; set; }

        public MainWindowViewModel() {

            CurrentContent = new SpoonacularView();
        }

    }
}
