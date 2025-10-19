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
    /// Interaction logic for UpdateStaffScreen.xaml
    /// </summary>
    public partial class DeleteStaffScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        private ObservableCollection<Staff> _staffList;
        Staff staffToDelete = null;

        public DeleteStaffScreen()
        {
            InitializeComponent();
            GetStaff();

        }

        private void GetStaff()
        {
            _staffList = new ObservableCollection<Staff>(_context.Staff.ToList());
            StaffDataGrid.ItemsSource = _staffList;

        }




        private void DeleteStaff(object s, RoutedEventArgs e)
        {

           staffToDelete = (s as FrameworkElement).DataContext as Staff;
            if (staffToDelete == null)
            {
                MessageBox.Show("No Staff Selected");
                return;
            }

            _context.Staff.Remove(staffToDelete);
            _context.SaveChanges();
            GetStaff();


                      
        }



    }
}
