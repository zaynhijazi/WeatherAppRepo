using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WeatherApp.Models.Home
{
    public class HomeViewModel
	{
        [Required]
		[RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Zip Code must be 5 digits or 5 digits followed by a hypnen and four digits")]
		[Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "The zip code must be between {2} and {1} characters long.")]
        public string ZipCode { get; set; }
	}
}

