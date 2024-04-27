using System;
using Newtonsoft.Json;

namespace WeatherApp.Common
{
	public class Place
    {
       [JsonProperty("place name")]
       public string PlaceName { get; set; }
       public double longitude { get; set; }
       public double latitude { get; set; }
       public string state { get; set; }
       [JsonProperty("state abbreviation")]
       public string StateAbbreviation { get; set; }
    }
}

