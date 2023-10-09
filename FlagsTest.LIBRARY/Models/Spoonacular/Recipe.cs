using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.Spoonacular
{
    public class Recipe
    {
        public Recipe()
        {
            Method = new RecipeMethod();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public List<Ingredient> Ingredients { get; set;}
        public RecipeMethod Method { get; set; }
    }
}
