using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.Movies
{
    public class CloseCastDetailsCommand : CommandBase
    {
        private MoviesViewModel _vm;

        public CloseCastDetailsCommand(MoviesViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            //_vm.ShowMovieDetails = true;
            //_vm.ShowCastDetails = false;
            // call to get the cast details would go here but endpoint not returning any cast details for any given movie id.

        }
    }
}
