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
        public BookAppointment()
        {
            InitializeComponent();
            TimeSlotBox.ItemsSource = new ObservableCollection<Timeslot>(_context.Timeslots.ToList());
       
        }



        private void CancelBtn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewEntities());
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TimeSlotBox.SelectedItem is Timeslot selectedTimeSlot && AppointmentDatePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = AppointmentDatePicker.SelectedDate.Value;
                Appointment appointment = new Appointment
                {
                    Date = DateOnly.FromDateTime(selectedDate),
                    StartTime = selectedTimeSlot,
                    Details = DetailsBox.Text,
                    PetName = PetNameBox.Text,
                    CustomerName = CustomerNameBox.Text 
                };
                if (_context.Appointments.Any(a => a.Date == appointment.Date && a.StartTimeId == appointment.StartTimeId))
                {
                    MessageBox.Show("The selected time slot is already booked. Please choose a different time.");
                    return;
                }
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                MessageBox.Show("Appointment booked successfully!");
                
            }
            else
            {
                MessageBox.Show("Please select a date and time slot.");
            }
        }

   
    }
}
