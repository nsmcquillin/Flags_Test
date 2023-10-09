using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.Movies
{
    public class ShowCastDetailsCommand : CommandBase
    {
        private MoviesViewModel _vm;

        public ShowCastDetailsCommand(MoviesViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            //_vm.ShowMovieDetails = false;
            //_vm.ShowCastDetails = true;
            // call to get the cast details would go here but endpoint not returning any cast details for any given movie id.

        }
    }
}
