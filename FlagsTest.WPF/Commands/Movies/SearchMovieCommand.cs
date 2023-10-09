using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.Movies
{
    public class SearchMovieCommand :CommandBase
    {
        private MoviesViewModel _vm;

        public SearchMovieCommand(MoviesViewModel vm)
        {
            _vm = vm;
        }
        public async override void Execute(object parameter)
        {
            _vm.MovieList = await MoviesAPI.GetMovies(_vm.SearchCriteria);

        }
    }
}
