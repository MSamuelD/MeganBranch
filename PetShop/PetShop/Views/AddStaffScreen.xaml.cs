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
    public partial class AddStaffScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        Staff newStaff = new Staff();


        public AddStaffScreen()
        {
            InitializeComponent();

            NewStaffDataGrid.DataContext = newStaff;
    


        }

        private bool HasPropertyErrors(IDataErrorInfo obj)
        {
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(obj))
            {
                if (obj[p.Name] != null) return true; 
            }
            return false;
        }


        private void AddStaff(object s, RoutedEventArgs e)
        {

            DateTime selectedDate = DOBDatePicker.SelectedDate.Value;
            newStaff.DateOfBirth = DateOnly.FromDateTime(selectedDate);
            if (HasPropertyErrors(newStaff))
            {
                System.Windows.MessageBox.Show("Please fix validation errors before saving.");
                return;
            }

            System.Windows.MessageBox.Show("Saved.");

            
            _context.Staff.Add(newStaff);
            _context.SaveChanges();

        }





    }
}
