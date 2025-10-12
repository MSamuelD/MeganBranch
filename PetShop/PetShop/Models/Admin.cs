using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class  Admin : Staff
    {
        public Admin(int id, string firstName, string lastName, DateOnly dateOfBirth, string email, string phoneNumber, string streetNumber, string streetName, string city, string state, int zipCode, string country, string password)
            : base(id, firstName, lastName, dateOfBirth, email, phoneNumber, streetNumber, streetName, city, state, zipCode, country, password)
        {
        }
        public Admin(int id, string email, string password)
            : base(id, "", "", new DateOnly(), email, "", "", "", "", "", 0, "", password)
        {
        }
    }
}
