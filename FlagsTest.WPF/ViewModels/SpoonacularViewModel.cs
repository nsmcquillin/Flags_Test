using FlagsTest.LIBRARY.APIHelpers;
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
            _title = "SPOONACULAR - RECIPES";
            SearchRecipesCommand = new SearchRecipesCommand(this);
            GetRecipeCommand = new GetRecipeCommand(this);
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
                NotifyPropertyChanged();
            }
        }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                NotifyPropertyChanged();
                
                
            }
        }

        private List<RecipeMethodStep> _selectedRecipeInstructions;
        public  List<RecipeMethodStep> SelectedRecipeInstructions
        {
            get { 
                return _selectedRecipe.Instructions[0].Steps;
            }            
        }

        private int _selectedRecipeId;
        public int SelectedRecipeId
        {
            get { return _selectedRecipeId; }
            set
            {
                _selectedRecipeId = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchRecipesCommand {  get; }

        public ICommand GetRecipeCommand { get; }       

        
    }
}
