using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.Spoonacular
{
    public class GetRecipeCommand : CommandBase
    {
        private SpoonacularViewModel _vm;

        public GetRecipeCommand(SpoonacularViewModel vm)
        {
            _vm = vm;
        }
        public async override void Execute(object parameter)
        {
            _vm.SelectedRecipe = await SpoonacularAPI.GetRecipeIngredients(_vm.SelectedRecipe);

        }
    }
}
