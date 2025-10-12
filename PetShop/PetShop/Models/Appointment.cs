using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    [PrimaryKey(nameof(Date), nameof(StartTimeId))]
    public class Appointment
    {

        public string PetName { get; set; }
        public string CustomerName { get; set; }
        public string Details { get; set; }
        public Timeslot StartTime { get; set; }
        public string StartTimeId { get; set; }
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
    }
}
