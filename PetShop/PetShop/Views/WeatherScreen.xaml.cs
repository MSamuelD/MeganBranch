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
        
        private Uri Url = new("https://api.openweathermap.org/data/2.5/weather?q=Sydney&appid=f8e812b271726c264aca84cf7fe2025e");
        public WeatherScreen()
        {
            InitializeComponent();
            getWeather();
        }
        public async void getWeather()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(Url);
                var jsonString = await result.Content.ReadAsStringAsync();
                Root weatherInfo = JsonSerializer.Deserialize<Root>(jsonString);
                TestThing.Text = (weatherInfo.weather[0].description);
                WeatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/wn/{weatherInfo.weather[0].icon}.png"));
                //https://www.youtube.com/watch?v=FEObLap1iGE
            }


            //TestThing.Text = weatherInfo.city.name;
            //TestThing.Text = $"Weather in {weatherInfo.city.name}, {weatherInfo.city.country}\n" +
            //    $"Temperature: {Math.Round(weatherInfo.lists[0].temp.day - 273.15)}°C\n" +
            //    $"Min: {Math.Round(weatherInfo.lists[0].temp.min - 273.15)}°C, Max: {Math.Round(weatherInfo.lists[0].temp.max - 273.15)}°C\n" +
            //    $"Humidity: {weatherInfo.lists[0].humidity}%\n" +
            //    $"Description: {weatherInfo.lists[0].weather[0].description}";

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //https://json2csharp.com/
        public class Clouds
        {
            public int all { get; set; }
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
        }

        public class Root
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Sys
        {
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }



    }
}
