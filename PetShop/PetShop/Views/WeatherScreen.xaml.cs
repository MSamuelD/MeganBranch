using Azure;
using PetShop.Models;
using PetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace PetShop.Views
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class WeatherScreen : Window
    {
        
        
        public WeatherScreen()
        {
            InitializeComponent();
            SetWeatherDetails();
        }
        
        
        public async void SetWeatherDetails()
        {
            Task<List<string>> weatherTask = WeatherVM.GetWeather();
            List<string> jsonString = await weatherTask;
            WeatherAPI.Root weatherInfo = JsonSerializer.Deserialize<WeatherAPI.Root>(jsonString[1]);

            TestThing.Text = (weatherInfo.weather[0].description);
            WeatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/wn/{weatherInfo.weather[0].icon}.png"));
            //https://www.youtube.com/watch?v=FEObLap1iGE
            SuggestionTxt.Text = WeatherVM.SetWeatherSuggestion(weatherInfo.weather[0].description);
            HumidityTxt.Text = ($"Humidity: {weatherInfo.main.humidity}%");
            DegreeTxt.Text = ($"Temperature: {Math.Round(weatherInfo.main.temp - 273.15)}°C");
        }
        
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
