using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpdateCustomerScreen.xaml
    /// </summary>
    public partial class UpdateCustomerScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        private ObservableCollection<Customer> _CustomerList;
        Customer selectedCustomer = new Customer();

        public UpdateCustomerScreen()
        {
            InitializeComponent();
            GetCustomer();

        }

        private void GetCustomer()
        {
            _CustomerList = new ObservableCollection<Customer>(_context.Customers.ToList());
            CustomerDataGrid.ItemsSource = _CustomerList;

        }

        private void SelectCustomerToEdit(object s, RoutedEventArgs e)
        {
            selectedCustomer = (s as FrameworkElement).DataContext as Customer;
            UpdateCustomerGrid.DataContext = selectedCustomer;
        }


        private void UpdateCustomer(object s, RoutedEventArgs e)
        {

            DateTime selectedDate = DOBDatePicker.SelectedDate.Value;
            selectedCustomer.DateOfBirth = DateOnly.FromDateTime(selectedDate);
            _context.Update(selectedCustomer);
            _context.SaveChanges();
            GetCustomer();
        }



    }
}
