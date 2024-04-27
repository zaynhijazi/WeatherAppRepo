using System;
using Newtonsoft.Json;
namespace WeatherApp.Common
{
    public class Area
    {
        [JsonProperty("post code")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public Place[] places { get; set; }
    }  
}

