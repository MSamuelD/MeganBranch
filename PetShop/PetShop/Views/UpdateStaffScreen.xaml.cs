using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpdateStaffScreen.xaml
    /// </summary>
    public partial class UpdateStaffScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        private ObservableCollection<Staff> _staffList;
        Staff selectedStaff = null;

        public UpdateStaffScreen()
        {
            InitializeComponent();
            GetStaff();


        }

        private void GetStaff()
        {
            _staffList = new ObservableCollection<Staff>(_context.Staff.ToList());
            StaffDataGrid.ItemsSource = _staffList;

        }

        private void SelectStaffToEdit(object s, RoutedEventArgs e)
        {
            selectedStaff = (s as FrameworkElement).DataContext as Staff;
            UpdateStaffGrid.DataContext = selectedStaff;
        }

        private bool HasPropertyErrors(IDataErrorInfo obj)
        {
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(obj))
            {
                if (obj[p.Name] != null) return true;
            }
            return false;
        }

        private void UpdateStaff(object s, RoutedEventArgs e)
        {

            if (selectedStaff == null)
            {
                MessageBox.Show("No staff selected");
                return;
            }

            if (!DOBDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Date cannot be left blank");
                return;
            }


            DateTime selectedDate = DOBDatePicker.SelectedDate.Value;
            selectedStaff.DateOfBirth = DateOnly.FromDateTime(selectedDate);

            if (HasPropertyErrors(selectedStaff))
            {
                MessageBox.Show("Please fix validation errors before saving.");
                return;
            }

            _context.Staff.Update(selectedStaff);
            _context.SaveChanges();
            MessageBox.Show("Staff Updated");
            GetStaff();

        }
    }
}
