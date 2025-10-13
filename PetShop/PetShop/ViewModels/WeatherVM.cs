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
        private Uri Url = new("https://api.openweathermap.org/data/2.5/weather?q=Sydney&appid=f8e812b271726c264aca84cf7fe2025e");
        public static async Task<string> GetWeather()
        {
            string response = "123";
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(new Uri("https://api.openweathermap.org/data/2.5/weather?q=Sydney&appid=f8e812b271726c264aca84cf7fe2025e"));
                Debug.WriteLine(result);
                var jsonString = await result.Content.ReadAsStringAsync();
                WeatherAPI.Root weatherInfo = JsonSerializer.Deserialize<WeatherAPI.Root>(jsonString);
                
                response = result.StatusCode.ToString();
            }
            return response;

            //TestThing.Text = weatherInfo.city.name;
            //TestThing.Text = $"Weather in {weatherInfo.city.name}, {weatherInfo.city.country}\n" +
            //    $"Temperature: {Math.Round(weatherInfo.lists[0].temp.day - 273.15)}°C\n" +
            //    $"Min: {Math.Round(weatherInfo.lists[0].temp.min - 273.15)}°C, Max: {Math.Round(weatherInfo.lists[0].temp.max - 273.15)}°C\n" +
            //    $"Humidity: {weatherInfo.lists[0].humidity}%\n" +
            //    $"Description: {weatherInfo.lists[0].weather[0].description}";

        }
    }
}
