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
    /// Interaction logic for ViewEntities.xaml
    /// </summary>
    public partial class ViewEntities : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        public ViewEntities()
        {
            InitializeComponent();

        }

        private void RoleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string role = selectedItem.Content.ToString();
                switch (role)
                {
                    case "Pets":
                        DisplayGrid.ItemsSource = new ObservableCollection<Pet>(_context.Pets.ToList());  
                        break;
                    case "Customers":
                        DisplayGrid.ItemsSource =  new ObservableCollection<Customer>(_context.Customers.ToList());
                        break;
                    case "Staff":
                        DisplayGrid.ItemsSource = new ObservableCollection<Staff>(_context.Staff.ToList());
                        break;
         
                    default:
                        DisplayGrid.ItemsSource = null; 
                        break;
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string role = selectedItem.Content.ToString();
                switch (role)
                {
                    case "Pets":
                        this.NavigationService.Navigate(new AddStaffScreen());
                        break;
                    case "Customers":
                        this.NavigationService.Navigate(new AddCustomerScreen());
                        break;
                    case "Staff":
                        this.NavigationService.Navigate(new AddStaffScreen());
                        break;
                    
                    default:
                        DisplayGrid.ItemsSource = null;
                        break;
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string role = selectedItem.Content.ToString();
                switch (role)
                {
                    case "Pets":
                        this.NavigationService.Navigate(new UpdateStaffScreen());
                        break;
                    case "Customers":
                        this.NavigationService.Navigate(new UpdateStaffScreen());
                        break;
                    case "Staff":
                        this.NavigationService.Navigate(new UpdateStaffScreen());
                        break;

                    default:
                        DisplayGrid.ItemsSource = null;
                        break;
                }
            }
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string role = selectedItem.Content.ToString();
                switch (role)
                {
                    case "Pets":
                        this.NavigationService.Navigate(new DeleteStaffScreen());
                        break;
                    case "Customers":
                        this.NavigationService.Navigate(new DeleteCustomerScreen());
                        break;
                    case "Staff":
                        this.NavigationService.Navigate(new DeleteStaffScreen());
                        break;

                    default:
                        DisplayGrid.ItemsSource = null;
                        break;
                }
            }
        }
    }
}
