using PetShop.Data;
using PetShop.Models;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserNameBox.Text;
            string password = PasswordBox.Text;
            List<Admin> admins = _context.Admin.ToList();
            List<Customer> customers = _context.Customers.ToList();
            List<Staff> staffs = _context.Staff.ToList();
            Customer loggedInCustomer = customers.FirstOrDefault(c => c.Email == username && c.Password == password);
            
            
            Staff loggedInStaff = staffs.FirstOrDefault(s => s.Email == username && s.Password == password);
           
            Admin loggedInAdmin = admins.FirstOrDefault(a => a.Email == username && a.Password == password);
            if (loggedInAdmin != null)
            {
                MessageBox.Show("Login Successful!");
                NavigationService.Navigate(new AdminScreen());
                return;
            }
            if (loggedInCustomer != null)
            {
            }
            if (loggedInStaff != null)
            {
                MessageBox.Show("Login success!, feature not implemented");

                return;
            }
            MessageBox.Show("Invalid username or password.");

        }
    }
}
