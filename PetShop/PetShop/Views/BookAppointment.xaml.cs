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
    /// Interaction logic for BookAppointment.xaml
    /// </summary>
    public partial class BookAppointment : Page
    {
        private readonly PetShopContext _context = new PetShopContext();
        public readonly ObservableCollection<Timeslot> BoxItems;
        public BookAppointment()
        {
            InitializeComponent();
            BoxItems = new ObservableCollection<Timeslot>(_context.Timeslots.ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Weather());
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

        }

   
    }
}
