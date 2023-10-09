using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
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

namespace FlagsTest.WPF.Views
{
    /// <summary>
    /// Interaction logic for MoviesView.xaml
    /// </summary>

        public partial class MoviesView : UserControl
        {
            public MoviesView()
            {
                InitializeComponent();
                DataContext = new MoviesViewModel();

            }

            private void lstMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            if (lstMovies.SelectedItem != null)
            {
                bdrSelectedMovie.Visibility = Visibility.Visible;
                //((MoviesViewModel)DataContext).SelectedMovie = await MoviesAPI.GetMovie(((MoviesViewModel)DataContext).SelectedMovie.Id);

            }
            else
            {
                bdrSelectedMovie.Visibility = Visibility.Collapsed;
            }
        }
        }
}
