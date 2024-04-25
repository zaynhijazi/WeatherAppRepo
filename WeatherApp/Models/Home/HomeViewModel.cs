using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WeatherApp.Models.Home
{
	public class HomeViewModel
	{
		[RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$")]
		[Display(Name = "Please enter your zip code below")]
        [Required(ErrorMessage = "The zip code field is required.")]
        public string ZipCode { get; set; }
	}
}

