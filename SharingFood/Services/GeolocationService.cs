using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharingFood.Models;
using RestSharp;

namespace SharingFood.Services
{
    public interface IGeolocationService
    {
        string GetCity();
        List<string> GetNearCities(int radius);
    }

    public class GeolocationService : IGeolocationService
    {
        public string GetCity()
        {
            var client = new WebClient();

            var result = client.DownloadString($"https://geo.ipify.org/api/v1?apiKey=at_hXJM5D8w2BpfgyipxoH0xqlUw5tmt");

            GeolocationModel model = JsonConvert.DeserializeObject<GeolocationModel>(result);

            return model.City;
        }

        public List<string> GetNearCities(int radius)
        {
            var client = new RestClient($"https://wft-geo-db.p.rapidapi.com/v1/geo/cities/Q60/nearbyCities?radius={radius}");

            var request = new RestRequest(Method.GET);

            request.AddHeader("x-rapidapi-host", "wft-geo-db.p.rapidapi.com");

            request.AddHeader("x-rapidapi-key", "");

            IRestResponse response = client.Execute(request);

            GeolocationModel model = JsonConvert.DeserializeObject<GeolocationModel>(response.Content);

            return model.city;
        }
    }
}
