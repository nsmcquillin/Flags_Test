using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.TheRundown
{
    public class SearchSportsCommand : CommandBase
    {
        private TheRundownViewModel _vm;

        public SearchSportsCommand(TheRundownViewModel vm)
        {
            _vm = vm;
        }
        public async override void Execute(object parameter)
        {
            _vm.SportList = await TheRundownAPI.GetSports();

        }
    }
}
