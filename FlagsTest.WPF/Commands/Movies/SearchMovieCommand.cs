using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.LIBRARY.Models.Movies;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FlagsTest.WPF.Commands.Movies
{
    public class SearchMovieCommand :CommandBase
    {
        private MoviesViewModel _vmMovies;
       
        public SearchMovieCommand(MoviesViewModel vmMovies)
        {
            _vmMovies = vmMovies;            
        }
        public async override void Execute(object parameter)
        {
            Task<List<Movie>> getMovies = Task.Run(() => MoviesAPI.GetMovies(_vmMovies.SearchCriteria));

            _vmMovies.MainWindowVM.SetAppBusy();
            await getMovies;
            if (getMovies.IsCompleted)
            {
                _vmMovies.MovieList = getMovies.Result;
                _vmMovies.MainWindowVM.SetAppNotBusy();
            }

           // ((MainWindowViewModel)Application.Current.MainWindow.DataContext).AppBusy = true;
            //_vm.MovieList = await MoviesAPI.GetMovies(_vm.SearchCriteria);
            //((MainWindowViewModel)Application.Current.MainWindow.DataContext).AppBusy = false;

        }
    }
}
