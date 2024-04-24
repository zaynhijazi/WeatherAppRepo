using System;
namespace WeatherApp.Common
{
	public class Current
	{
        public string time { get; set; }
        public int interval { get; set; }
        public double temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
        public double apparent_temperature { get; set; }
        public int is_day { get; set; }
        public double precipitation { get; set; }
        public double rain { get; set; }
        public double showers { get; set; }
        public double snowfall { get; set; }
        public int weather_code { get; set; }
        public double cloud_cover { get; set; }
        public double pressure_msl { get; set; }
        public double surface_pressure { get; set; }
        public double wind_speed_10m { get; set; }
        public int wind_direction_10m { get; set; }
        public double wind_gusts_10m { get; set; }
    }
}

