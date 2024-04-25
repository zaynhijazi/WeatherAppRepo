using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenMeteo;
using WeatherApp.Models;
using WeatherApp.WeatherService;
using WeatherApp.Common;
using WeatherApp.Models.Home;

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
        // Define the latitude and longitude parameters, this is the lat and long of my zipcode.
        double latitude = 38.9194;
        double longitude = -76.7871;

        string apiUrl = "https://api.open-meteo.com/v1/forecast";
        string currentParameters = "temperature_2m,relative_humidity_2m,apparent_temperature,is_day,precipitation,rain,showers,snowfall,weather_code,cloud_cover,pressure_msl,surface_pressure,wind_speed_10m,wind_direction_10m,wind_gusts_10m";
        string queryString = $"?latitude={latitude.ToString()}&longitude={longitude.ToString()}";
        string queryString1 = $"&current={currentParameters}&temperature_unit=fahrenheit&timezone=auto";

        // Concatenate the base URL and query parameters
        string finalUrl = apiUrl + queryString + queryString1;

        Console.WriteLine("Final URL: " + finalUrl);

        // Create an instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send a GET request to the API and get the response
                HttpResponseMessage response = await client.GetAsync(finalUrl);

                // Check if the response is successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    WeatherData data = JsonConvert.DeserializeObject<WeatherData>(responseBody);
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
        HomeViewModel viewModel = new HomeViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(HomeViewModel viewModel)
    {
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

