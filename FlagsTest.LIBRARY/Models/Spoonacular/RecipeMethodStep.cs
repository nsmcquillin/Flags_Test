using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.Spoonacular
{
    public class RecipeMethodStep
    {
       
        public int Number { get; set; }
        public string Step { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeEquipment> Equipment { get; set; }
    }
}
