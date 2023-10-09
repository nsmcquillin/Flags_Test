using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlagsTest.WPF.Views
{
    /// <summary>
    /// Interaction logic for SpoonacularView.xaml
    /// </summary>
    public partial class SpoonacularView : UserControl
    {
        public SpoonacularView()
        {
            InitializeComponent();
            DataContext = new SpoonacularViewModel();
            
        }

        private async void lstRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((SpoonacularViewModel)DataContext).SelectedRecipe = await SpoonacularAPI.GetRecipeIngredients(((SpoonacularViewModel)DataContext).SelectedRecipe);


        }

       
    }
}
