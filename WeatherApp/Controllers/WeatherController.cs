using System;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models.Home;
using WeatherApp.Models.Weather;

namespace WeatherApp.Controllers
{
	public class WeatherController : Controller
	{
		public WeatherController()
		{
		}

        public IActionResult Index(WeatherViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}

