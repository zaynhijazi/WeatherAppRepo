using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenMeteo;
using WeatherApp.Models;
using WeatherApp.Common;
using WeatherApp.Models.Home;
using WeatherApp.Business;
using WeatherApp.Helpers;
using WeatherApp.Models.Weather;

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
           Tuple<string,string> tuple = WeatherCodeInterpreter.InterpretWeatherCode(weather.current.weather_code, weather.current.is_day);
            WeatherViewModel weatherviewModel = new WeatherViewModel
            {
                PlaceName = area.places[0].PlaceName,
                State = area.places[0].state,
                CurrentTemperature = (int)Math.Round(weather.current.temperature_2m), // Round up and convert to integer
                WeatherCode = weather.current.weather_code,
                filePath = tuple.Item1,
                weatherDesc = tuple.Item2
            };
            return RedirectToAction("Index", "Weather", weatherviewModel);
        }
        catch(HttpRequestException ex)
        {
            string callStack = ex.StackTrace;
            if (callStack.Contains("GetAreaDetails"))
            {
                Console.WriteLine("We couldn't establish a connection or the zip code that was given is not a valid zip code.");
            }
            else
            {
                Console.WriteLine("The Weather API has an issue");
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

