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
using PetShop.Data;
using PetShop.Models;
using System;
using System.Linq;


namespace PetShop.Views
{
    public partial class AddPetScreen : Page
    {
        private readonly PetShopContext _context = new PetShopContext();

        public AddPetScreen()
        {
            InitializeComponent();

            // 1) Create a object
            this.DataContext = new Pet();

            // 2) Bind the Type
            var types = _context.Types.ToList();
            TypeBox.ItemsSource = types;
            TypeBox.DisplayMemberPath = "Name";
            TypeBox.SelectedValuePath = "Id";

            // 3) Bind the customer could be null(for no owner pet)
            var customers = _context.Customers
                .Select(c => new
                {
                    c.Id,
                    FullName = ((c.FirstName ?? "").Trim() + " " + (c.LastName ?? "").Trim()).Trim()
                })
                .ToList();

            CustomerBox.ItemsSource = customers;
            CustomerBox.DisplayMemberPath = "FullName";
            CustomerBox.SelectedValuePath = "Id";
            CustomerBox.SelectedIndex = -1; // (for no owner pet)
        }

        private void AddPet_Click(object sender, RoutedEventArgs e)
        {

            if (this.DataContext is not Pet pet)
            {
                MessageBox.Show("Binding error: DataContext is not Pet.");
                return;
            }

            // check required fields
            if (string.IsNullOrWhiteSpace(pet.Name))
            {
                MessageBox.Show("Please enter the pet name.");
                return;
            }
            if (pet.TypeId <= 0)
            {
                MessageBox.Show("Please select a pet type.");
                return;
            }
            // CustomerId could be null 

            try
            {
                _context.Pets.Add(pet);
                _context.SaveChanges();
                MessageBox.Show("New Pet Added");

                MessageBox.Show("Pet added successfully.");
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding pet: " + ex.Message);
            }
        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
