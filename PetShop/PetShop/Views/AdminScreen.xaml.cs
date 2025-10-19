using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PetShop.Views
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Page
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        private void CustomerOptions_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new CustomerOptions());
        }

        private void StaffOptions_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new StaffOptions());
        }

        private void WeatherScreen_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new WeatherScreen());
        }

        private void BookingStatistics_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new BookingStatisticsPage());
        }

        private void Pet_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new AddPetScreen());
        }
    }
}