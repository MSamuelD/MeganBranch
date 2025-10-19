using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddCustomerScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        Customer newCustomer = new Customer();


        public AddCustomerScreen()
        {
            InitializeComponent();

            NewCustomerDataGrid.DataContext = newCustomer;

        }

        private bool HasPropertyErrors(IDataErrorInfo obj)
        {
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(obj))
            {
                if (obj[p.Name] != null) return true;
            }
            return false;
        }

        private void AddCustomer(object s, RoutedEventArgs e)
        {
            if (!DOBDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Date cannot be left blank");
                return;
            }
            DateTime selectedDate = DOBDatePicker.SelectedDate.Value;
            newCustomer.DateOfBirth = DateOnly.FromDateTime(selectedDate);
            if (HasPropertyErrors(newCustomer))
            {
                MessageBox.Show("Please fix validation errors before saving.");
                return;
            }

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            MessageBox.Show("New Customer Added");

        }





    }
}
