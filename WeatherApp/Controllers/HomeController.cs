using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenMeteo;
using WeatherApp.Models;
using WeatherApp.Common;
using WeatherApp.Models.Home;
using WeatherApp.Business;

namespace WeatherApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWeatherDataClient _weatherDataClient;

    public HomeController(ILogger<HomeController> logger, IWeatherDataClient weatherDataClient)
    {
        _logger = logger;
        _weatherDataClient = weatherDataClient;
    }

    public async Task<IActionResult> Index()
    {
        // Define the latitude and longitude parameters, this is the lat and long of my zipcode.
        double latitude = 38.9194;
        double longitude = -76.7871;

        try
        {
            _weatherDataClient.GetCurrentWeather(latitude, longitude);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
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

