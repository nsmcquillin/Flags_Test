using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            ((MainWindowViewModel)Application.Current.MainWindow.DataContext).AppBusy = true;
            _vm.RecipeList = await SpoonacularAPI.GetRecipes(_vm.SearchCriteria,0);
            ((MainWindowViewModel)Application.Current.MainWindow.DataContext).AppBusy = false;

        }
    }
}
