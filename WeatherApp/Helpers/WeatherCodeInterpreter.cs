using System;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp.Helpers
{
	public class WeatherCodeInterpreter
	{
        public static Tuple<string,string> InterpretWeatherCode(int weatherCode, int is_day)
        {
            string filePath = "";
            string weatherDesc = "";
            if (weatherCode == 0)
            {
                //0 is night, 1 is day
                if (is_day == 0)
                {
                    filePath = "/Weather-App-Images/clear-sky/clear-sky-night.png";
                }
                else
                {
                    filePath = "/Weather-App-Images/clear-sky/clear-sky-day.png";
                }
               weatherDesc =  "Clear sky";
            }
            else if (weatherCode == 1 || weatherCode == 2 || weatherCode == 3)
            {
                if (is_day == 0)
                {
                    filePath = "/Weather-App-Images/partly-cloudy/partly-cloudy-night.png";
                }
                else
                {
                    filePath = "/Weather-App-Images/partly-cloudy/partly-cloudy-day.png";
                }
                weatherDesc =  "Mainly clear, partly cloudy, and overcast";
            }
            else if (weatherCode == 45 || weatherCode == 48)
            {
                filePath = "/Weather-App-Images/fog.png";
                weatherDesc = "Fog and depositing rime";
            }
            else if (weatherCode == 51 || weatherCode == 53 || weatherCode == 55 || weatherCode == 56 || weatherCode == 57)
            {
                if (is_day == 0)
                {
                    filePath = "/Weather-App-Images/drizzle/drizzle-day.png";
                }
                else
                {
                    filePath = "/Weather-App-Images/drizzle/drizzle-night.png";
                }
                weatherDesc = "Drizzle: Light, moderate, and dense intensity";
            }
            else if (weatherCode == 61 || weatherCode == 63 || weatherCode == 65)
            {
                filePath = "/Weather-App-Images/rain/rain.png";
                weatherDesc ="Rain: Slight, moderate and heavy intensity";


            }
            else if (weatherCode == 66 || weatherCode == 67)
            {
                filePath = "/Weather-App-Images/rain/freezing-rain.png";
                weatherDesc = "Freezing Rain: Light and heavy intensity";

            }
            else if (weatherCode == 71 || weatherCode == 73 || weatherCode == 75 || weatherCode == 77)
            {
                filePath = "/Weather-App-Images/snow/snow.png";
                weatherDesc = "Snow fall: Slight, moderate, and heavy intensity";
                //return "Snow grains";
            }
            else if (weatherCode == 80 || weatherCode == 81 || weatherCode == 82)
            {
                filePath = "/Weather-App-Images/rain/rain-showers.png";
                weatherDesc ="Rain showers: Slight, moderate, and violent";
            }
            else if (weatherCode == 85 || weatherCode == 86)
            {
                filePath = "/Weather-App-Images/snow/snow-showers.png";
                weatherDesc = "Snow showers slight and heavy";
            }
            else if (weatherCode == 95 || weatherCode == 96 || weatherCode == 99)
            {
                filePath = "/Weather-App-Images/thunderstorm.png";
                weatherDesc = "Thunderstorm: Slight or moderate"; 
            }
            else
            {
                //return "Unknown";
            }
            return new Tuple<string, string>(filePath, weatherDesc);
        }
    }
}

