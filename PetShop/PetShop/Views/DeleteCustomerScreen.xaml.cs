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
    public partial class DeleteCustomerScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        private ObservableCollection<Customer> _customerList;
        Customer customerToDelete = null;

        public DeleteCustomerScreen()
        {
            InitializeComponent();
            GetCustomer();

        }

        private void GetCustomer()
        {
            _customerList = new ObservableCollection<Customer>(_context.Customers.ToList());
            CustomerDataGrid.ItemsSource = _customerList;

        }




        private void DeleteCustomer(object s, RoutedEventArgs e)
        {

            customerToDelete = (s as FrameworkElement).DataContext as Customer;
            if (customerToDelete == null)
            {
                MessageBox.Show("No customer selected");
                return;
            }
            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
            GetCustomer();
        }



    }
}
