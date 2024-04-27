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
    private readonly IAreaClient _areaClient;

    public HomeController(ILogger<HomeController> logger, IWeatherDataClient weatherDataClient, IAreaClient areaClient)
    {
        _logger = logger;
        _weatherDataClient = weatherDataClient;
        _areaClient = areaClient;
    }

    public async Task<IActionResult> Index()
    {
        // Define the latitude and longitude parameters, this is the lat and long of my zipcode.
        //double latitude = 38.9194;
        //double longitude = -76.7871;
        HomeViewModel viewModel = new HomeViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(HomeViewModel viewModel)
    {
        
        try
        {
           Area area = await _areaClient.GetAreaDetails(viewModel.ZipCode);
           WeatherData weather = await _weatherDataClient.GetCurrentWeather(area.places[0].latitude, area.places[0].longitude);
        }
        catch(HttpRequestException ex)
        {
            var name = new StackTrace(ex).GetFrame(0).GetMethod().Name;
            if(String.Equals("GetCurrentWeather", name))
            {
                Console.WriteLine("The Weather API has an issue");
            }
            else
            {
                Console.WriteLine("The ZipCode API has an issue");
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

