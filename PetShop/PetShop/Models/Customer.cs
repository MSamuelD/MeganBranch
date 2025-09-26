using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Customer : Person
    {
        public List<Pet> Pets { get; set; }
        public List<DateTime> Bookings { get; set; }
    }
}
