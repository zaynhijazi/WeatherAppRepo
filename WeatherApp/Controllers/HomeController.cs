﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenMeteo;
using WeatherApp.Models;
using WeatherApp.WeatherService;

namespace WeatherApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWeatherService _weatherService;

    public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Index()
    {
        // Define the latitude and longitude parameters
        double latitude = 38.9194;
        double longitude = -76.7871;

        //// Define the URL of the weather API
        //string baseUrl = "https://api.open-meteo.com/v1/forecast";

        //// Define the query string
        //string queryString = $"?latitude={latitude.ToString()}&longitude={longitude.ToString()}";

        //// Combine the base URL and query string to form the request URL
        //string requestUrl = baseUrl + queryString;

        string apiUrl = "https://api.open-meteo.com/v1/forecast";
        string currentParameters = "temperature_2m,relative_humidity_2m,apparent_temperature,is_day,precipitation,rain,showers,snowfall,weather_code,cloud_cover,pressure_msl,surface_pressure,wind_speed_10m,wind_direction_10m,wind_gusts_10m";
        string queryString = $"?latitude={latitude.ToString()}&longitude={longitude.ToString()}";
        string queryString1 = $"&current ={ currentParameters}";
        string requestUrl = apiUrl + queryString + queryString1;

        // Create an instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send a GET request to the API and get the response
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                // Check if the response is successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Process the response body as needed
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

