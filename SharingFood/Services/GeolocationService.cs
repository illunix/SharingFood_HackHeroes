using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharingFood.Models;
using RestSharp;
using System.Net.Http;

namespace SharingFood.Services
{
    public interface IGeolocationService
    {
        string GetCity();
        List<string> GetNearCities(int radius);
    }

    public class GeolocationService : IGeolocationService
    {
        static readonly HttpClient _client = new HttpClient(new HttpClientHandler { UseProxy = false });

        public string GetCity()
        {
            var json = string.Empty;

            Task.Run(async () =>
            {
                json = await _client.GetStringAsync("https://geo.ipify.org/api/v1?apiKey=at_hXJM5D8w2BpfgyipxoH0xqlUw5tmt");
            }).Wait();

            GeolocationModel model = JsonConvert.DeserializeObject<GeolocationModel>(json);

            string unicode = model.location.City;

            return Uri.UnescapeDataString(unicode);
        }

        public List<string> GetNearCities(int radius)
        {
            var client = new WebClient();

            var result = client.DownloadString("https://wft-geo-db.p.rapidapi.com/v1/geo/cities/Q270/nearbyCities?radius=2");

            client.Headers.Add("x-rapidapi-host", "wft-geo-db.p.rapidapi.com");
            client.Headers.Add("x-rapidapi-key", "29d3738d70msh81a0f7b28c875e5p1086efjsn545dee79a112");

            GeolocationModel model = JsonConvert.DeserializeObject<GeolocationModel>(result);

            var list = new List<string>();

            foreach (var d in model.data)
            {
                list.Add(d.City);
            }

            return list;
        }
    }
}