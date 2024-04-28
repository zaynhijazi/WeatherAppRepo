using System;
namespace WeatherApp.Models.Weather
{
	public class WeatherViewModel
	{
            public string PlaceName { get; set; }
            public string State { get; set; }
            public int CurrentTemperature { get; set; }
            public int WeatherCode { get; set; }
            public string filePath { get; set; }
            public string weatherDesc { get; set; }
    }
}

