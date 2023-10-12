using FlagsTest.LIBRARY.Models.Movies;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.APIHelpers
{
    public static class MoviesAPI
    {

        private static string _apiKey = "d7ad1db3c1mshc13814405dba3dcp1f7fc4jsn3f46ff91e614";
        

        public static async Task<List<Movie>> GetMovies(string searchCriteria)
        {
            var url = "https://moviesdatabase.p.rapidapi.com/titles/search/title/" + searchCriteria + "?exact=false&info=base_info&titleType=movie";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);

            request.AddHeader("X-RapidAPI-Key", _apiKey);
            request.AddHeader("X-RapidAPI-Host", "moviesdatabase.p.rapidapi.com");

            RestResponse response = await client.ExecuteAsync(request);
            JObject jsonResponse = null;
            List<Movie> movieList = new List<Movie>();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
                    movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse["results"].ToString());

                    break;
                default:

                    break;

            }          

            return movieList;

        }        


    }
}
