using FlagsTest.LIBRARY.Models.Spoonacular;
using FlagsTest.WPF.Commands.Spoonacular;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlagsTest.WPF.ViewModels
{
    public class SpoonacularViewModel : ViewModelBase
    {
        public SpoonacularViewModel()
        {
            _searchCriteria = "aaa";
            SearchRecipesCommand = new SearchRecipesCommand(this);
        }              

        private string _searchCriteria;
        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                _searchCriteria = value;
                NotifyPropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        private List<Recipe> _recipeList;
        public List<Recipe> RecipeList
        {
            get { return _recipeList; }
            set
            {
                _recipeList = value;
            }
        }

        public ICommand SearchRecipesCommand {  get; }

        public ICommand SidebarListSelectedItemChanged { get; }


    }
}
