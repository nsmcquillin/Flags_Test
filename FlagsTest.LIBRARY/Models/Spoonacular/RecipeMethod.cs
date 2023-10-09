using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.Spoonacular
{
    public class RecipeMethod
    {
        public string Name { get; set; }
        public List<RecipeMethodStep> Steps { get; set; }
    }
}
