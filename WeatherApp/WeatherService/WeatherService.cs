using System;
using Microsoft.Extensions.Options;
using OpenMeteo;

namespace WeatherApp.WeatherService
{
	public class WeatherService: IWeatherService
    {
		public WeatherService()
		{
		}

        public async Task RunAsync()
        {
            // Before using the library you have to create a new client. 
            // Once created you can reuse it for every other api call you are going to make. 
            // There is no need to create multiple clients.
            //OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

            //WeatherForecastOptions test = new WeatherForecastOptions();
            //test.Temperature_Unit = TemperatureUnitType.fahrenheit;
            //test.Latitude = 38.9194f;
            //test.Longitude = -76.7871f; // Bowie

            //// Make a new api call to get the current weather in tokyo
            //WeatherForecast weatherData = await client.QueryAsync(test);
            //// Output the current weather to console
            //Console.WriteLine("Weather in Bowie, Maryland: " + weatherData.Current.Temperature + weatherData.CurrentUnits.Temperature);

            OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

            // Set custom options
            WeatherForecastOptions options = new WeatherForecastOptions();
            options.Temperature_Unit = TemperatureUnitType.fahrenheit;
            options.Latitude = 35.6895f;
            options.Longitude = 139.69171f; // For Tokyo

            // Make a new api call to get the current weather in tokyo
            WeatherForecast weatherData = await client.QueryAsync(options);

            // Output the current weather to console
            //Console.WriteLine("Weather in Tokyo: " + weatherData.CurrentWeather.Temperature + "°F");
        }
    }

    public interface IWeatherService
    {
        Task RunAsync();
    }
}

