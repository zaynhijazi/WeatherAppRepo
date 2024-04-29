using System;
using System.Net;
using Newtonsoft.Json;
using WeatherApp.Common;
namespace WeatherApp.Business
{
	public class WeatherDataService : IWeatherDataClient
    {
        //HttpClient injected by .NET Core
        private readonly HttpClient _client;

        public WeatherDataService(HttpClient client)
		{
            _client = client;
            _client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<WeatherData> GetCurrentWeather(double latitude, double longitude)
        {
            string currentParameters = "temperature_2m,relative_humidity_2m,apparent_temperature,is_day,precipitation,rain,showers,snowfall,weather_code,cloud_cover,pressure_msl,surface_pressure,wind_speed_10m,wind_direction_10m,wind_gusts_10m";
            string queryString = $"?latitude={latitude.ToString()}&longitude={longitude.ToString()}";
            string queryString1 = $"&current={currentParameters}&temperature_unit=fahrenheit&timezone=auto";

            string finalUrl = queryString + queryString1;

            using (var response = await _client.GetAsync(finalUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                     // Handle other error responses
                     throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
                }
                var stream = await response.Content.ReadAsStringAsync();
                WeatherData data = JsonConvert.DeserializeObject<WeatherData>(stream);
                return data;
            }
        }

    }
}

