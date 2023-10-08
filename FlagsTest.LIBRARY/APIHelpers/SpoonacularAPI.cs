using FlagsTest.LIBRARY.Models.Spoonacular;
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

            return null;
            //return JsonConvert.DeserializeObject<List<Recipe>>(response.Content);


        }
    }
}
