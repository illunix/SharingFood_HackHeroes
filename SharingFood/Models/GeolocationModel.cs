using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharingFood.Models
{
    public class GeolocationModel
    {
        [JsonProperty("data")]
        public List<Datum> data { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string City { get; set; }
    }

    public class Datum
    {
        [JsonProperty("city")]
        public string City { get; set; }
    }
}
