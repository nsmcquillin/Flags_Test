using FlagsTest.LIBRARY.Models.TheRundown;
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
    public static class TheRundownAPI
    {

        private static string _apiKey = "ogJj2OSqZXTqL5lYGqmeXTNgqbTdRxGR";

        public static async Task<List<Sport>> GetSports()
        {
            var url = "https://api.apilayer.com/therundown/sports";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("apikey", _apiKey);          

            RestResponse response = await client.ExecuteAsync(request);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            List<Sport> sportList = JsonConvert.DeserializeObject<List<Sport>>(jsonResponse["sports"].ToString());


            return sportList;


        }

        //public static async Task<> GetTeams(int sportId)
        //{
        //    string url = "https://api.apilayer.com/therundown/sports/" + sportId + "/teams";

        //    var client = new RestClient(url);
        //    var request = new RestRequest(url, Method.Get);
        //    request.AddHeader("apikey", _apiKey);

        //    //request.Parameters.AddParameter(Parameter.CreateParameter("id", searchCriteria, ParameterType.QueryString));

        //    RestResponse response = await client.ExecuteAsync(request);

        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    Sport sport = JsonConvert.DeserializeObject<Sport>(jsonResponse["results"].ToString());


        //    return sport;


        //}
    }
}
