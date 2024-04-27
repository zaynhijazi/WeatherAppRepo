using System;
using WeatherApp.Common;

namespace WeatherApp.Business
{
	public interface IAreaClient
	{
        Task<Area> GetAreaDetails(string ZipCode);

    }
}

