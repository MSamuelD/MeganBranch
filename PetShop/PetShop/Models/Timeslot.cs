using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Timeslot
    {
        public Timeslot() { }
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime => StartTime.AddMinutes(30);
        public bool IsBooked { get; set; }
    }
}
