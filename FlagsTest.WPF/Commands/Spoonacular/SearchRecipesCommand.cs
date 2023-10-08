using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.WPF.Commands.Spoonacular
{
    public class SearchRecipesCommand : CommandBase
    {
        private SpoonacularViewModel _vm;

        public SearchRecipesCommand(SpoonacularViewModel vm)
        {
            _vm = vm;
        }
        public async override void Execute(object parameter)
        {
            _vm.RecipeList = await SpoonacularAPI.GetRecipes(_vm.SearchCriteria,0);
            
        }
    }
}
