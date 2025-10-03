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
        public void getWeather()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(Url).Result;
               
                // ... inside getWeather()
                var jsonString = result.Content.ReadAsStringAsync().Result;
                TestThing.Text = jsonString;
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
        public class WeatherInfo
        {
            public City city { get; set; }
            public List<List> lists { get; set; }

        }
        public class City
        {
            public string name { get; set; }
            public string country { get; set; }
        }
        public class List
        {
            public Temp temp { get; set; }
            public int humidity { get; set; }
            public List<Weather> weather { get; set; }
        }
        public class Temp
        {
            public double day { get; set; }
            public double min { get; set; }
            public double max { get; set; }
            public double night { get; set; }
        
        }
        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }

        }

    }
}
