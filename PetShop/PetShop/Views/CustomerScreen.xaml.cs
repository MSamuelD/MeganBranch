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
    /// Interaction logic for CustomerScreen.xaml
    /// </summary>
    public partial class CustomerScreen : Page
    {
        public CustomerScreen()
        {
            InitializeComponent();
        }

        private void BookAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BookAppointment());
        }

        private void ServiceProgress_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServiceProgress());
        }

        private void WeatherScreen_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WeatherScreen());
        }
    }
}


