using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Appointment
    {
        public Appointment() { }
        public int Id { get; set; }
        public Timeslot Timeslot { get; set; }
        public Pet Pet { get; set; }
        public Customer Customer { get; set; }
        public string Details { get; set; }
    }
}
