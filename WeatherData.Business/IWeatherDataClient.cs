using System;
using WeatherApp.Common;

namespace WeatherApp.Business
{
	public interface IWeatherDataClient
	{
        Task<WeatherData> GetCurrentWeather(double latitude, double longitude);
    }
}

