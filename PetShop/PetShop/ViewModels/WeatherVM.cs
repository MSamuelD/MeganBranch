using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PetShop.ViewModels
{
    public class WeatherVM
    {
        /// <summary>
        /// Oh noo a hard coded API key, what could go wrong
        /// </summary>
        public static async Task<List<string>> GetWeather()
        {
            string jsonString = "";
            string response = "";
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?q=Sydney&appid=f8e812b271726c264aca84cf7fe2025e"));
                jsonString = await result.Content.ReadAsStringAsync();
                WeatherAPI.Root weatherInfo = JsonSerializer.Deserialize<WeatherAPI.Root>(jsonString);
                
                response = result.StatusCode.ToString();
            }
            return new List<string>() { response, jsonString };

           

        }
        public static string SetWeatherSuggestion(string weather)
        {
            if (weather.Contains("rain"))
            {
                return "It's raining, don't forget your umbrella!";
            }
            else if (weather.Contains("clear"))
            {
                return "It's a clear day, enjoy the sunshine!";
            }
            else if (weather.Contains("cloud"))
            {
                return "It's cloudy, a perfect day for a walk!";
            }
            else if (weather.Contains("snow"))
            {
                return "It's snowy, stay warm out there!";
            }
            else
            {
                return "Have a great day!";
            }
        }
    }
}
