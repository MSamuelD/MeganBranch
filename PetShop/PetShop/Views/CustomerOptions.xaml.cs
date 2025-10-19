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
    /// Interaction logic for CustomerOptions.xaml
    /// </summary>
    public partial class CustomerOptions : Page
    {
        public CustomerOptions()
        {
            InitializeComponent();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddCustomerScreen());
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {

            NavigationService?.Navigate(new UpdateCustomerScreen());
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

            NavigationService?.Navigate(new DeleteCustomerScreen());
        }
    }
}