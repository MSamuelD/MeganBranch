using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using PetShop.Models;
using System.Windows.Media.Animation;
namespace PetShop.Views
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class WeatherScreen : Window
    {
        /// <summary>
        /// Oh noo a hard coded API key, what could go wrong
        /// </summary>
        
        public WeatherScreen()
        {
            InitializeComponent();
            GetWeather();
        }
        
        private Uri Url = new("https://api.openweathermap.org/data/2.5/weather?q=Sydney&appid=f8e812b271726c264aca84cf7fe2025e");
        public async Task<string> GetWeather()
        {
            string response = "123";
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(Url);
                Debug.WriteLine(result);
                var jsonString = await result.Content.ReadAsStringAsync();
                WeatherAPI.Root weatherInfo = JsonSerializer.Deserialize<WeatherAPI.Root>(jsonString);
                TestThing.Text = (weatherInfo.weather[0].description);
                WeatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/wn/{weatherInfo.weather[0].icon}.png"));
                //https://www.youtube.com/watch?v=FEObLap1iGE
                SetWeatherSuggestion(weatherInfo.weather[0].description);
                response = result.StatusCode.ToString();
                Debug.WriteLine(response);
                TestThing.Text = response;
            }
            return response;

            //TestThing.Text = weatherInfo.city.name;
            //TestThing.Text = $"Weather in {weatherInfo.city.name}, {weatherInfo.city.country}\n" +
            //    $"Temperature: {Math.Round(weatherInfo.lists[0].temp.day - 273.15)}°C\n" +
            //    $"Min: {Math.Round(weatherInfo.lists[0].temp.min - 273.15)}°C, Max: {Math.Round(weatherInfo.lists[0].temp.max - 273.15)}°C\n" +
            //    $"Humidity: {weatherInfo.lists[0].humidity}%\n" +
            //    $"Description: {weatherInfo.lists[0].weather[0].description}";

        }
        public void SetWeatherSuggestion(string weather)
        {
            if (weather.Contains("rain"))
            {
                SuggestionTxt.Text = "It's raining, don't forget your umbrella!";
            }
            else if (weather.Contains("clear"))
            {
                SuggestionTxt.Text = "It's a clear day, enjoy the sunshine!";
            }
            else if (weather.Contains("cloud"))
            {
                SuggestionTxt.Text = "It's cloudy, a perfect day for a walk!";
            }
            else if (weather.Contains("snow"))
            {
                SuggestionTxt.Text = "It's snowy, stay warm out there!";
            }
            else
            {
                SuggestionTxt.Text = "Have a great day!";
            }
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        


    }
}
