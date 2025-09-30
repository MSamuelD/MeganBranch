using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    /// using date and timelot to map a session with the following format day-timeslot
    public class Session
    {
        public DateTime Date { get; set; }
        public Timeslot StartTime { get; set; }
        public Timeslot EndTime { get; set; }
    }
}
