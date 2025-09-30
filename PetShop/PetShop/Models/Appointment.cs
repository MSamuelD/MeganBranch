using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string PetName { get; set; }
        public Customer Customer { get; set; }
        public string Details { get; set; }
        public Timeslot StartTime { get; set; }
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
    }
}
