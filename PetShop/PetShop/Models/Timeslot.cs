using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Timeslot
    {
        [Key]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string TimeFormatted { get => Time.ToString("hh:mm tt"); }
    }
}
