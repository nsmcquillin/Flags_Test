using FlagsTest.LIBRARY.Models.Spoonacular;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.APIHelpers
{
    public static class SpoonacularAPI
    {

        private static string _apiKey = "ogJj2OSqZXTqL5lYGqmeXTNgqbTdRxGR";

        public static async Task<List<Recipe>> GetRecipes(string searchCriteria, int numberOfRecords)
        {
            var url = "https://api.apilayer.com/spoonacular/recipes/complexSearch";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("apikey", _apiKey);

            request.Parameters.AddParameter(Parameter.CreateParameter("query", searchCriteria, ParameterType.QueryString));

            RestResponse response = await client.ExecuteAsync(request);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            List<Recipe> recipeList = JsonConvert.DeserializeObject<List<Recipe>>(jsonResponse["results"].ToString());


            return recipeList;


        }

        public static async Task<Recipe> GetRecipeIngredients(Recipe recipe)
        {
            string url = "https://api.apilayer.com/spoonacular/recipes/" + recipe.Id + "/information";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("apikey", _apiKey);

            //request.Parameters.AddParameter(Parameter.CreateParameter("id", searchCriteria, ParameterType.QueryString));

            RestResponse response = await client.ExecuteAsync(request);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            recipe.Ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse["extendedIngredients"].ToString());
            recipe.Method = JsonConvert.DeserializeObject<RecipeMethod>(jsonResponse["analyzedInstructions"].ToString());

       
         

            return recipe;

        }

        public static async Task<List<Ingredient>> GetRecipeMethod(int recipeId)
        {
            string url = "https://api.apilayer.com/spoonacular/recipes/" + recipeId + "/information";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("apikey", _apiKey);

            //request.Parameters.AddParameter(Parameter.CreateParameter("id", searchCriteria, ParameterType.QueryString));

            RestResponse response = await client.ExecuteAsync(request);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            List<Ingredient> ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse["extendedIngredients"].ToString());

            foreach (var ing in ingredients)
            {
                ing.Image = "https://spoonacular.com/recipeImages/" + ing.Image;
            }

            return ingredients;


        }
    }
}
