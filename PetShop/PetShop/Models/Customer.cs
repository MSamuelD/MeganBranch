using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Customer : Person, IValidatableObject
    {
        public Customer() 
        {
            
        }
        public Customer(int id, string firstName, string lastName, DateOnly dateOfBirth, string email, string phoneNumber, string streetNumber, string streetName, string city, string state, int zipCode, string country, string password) 
            : base(id, firstName, lastName, dateOfBirth, email, phoneNumber, streetNumber, streetName, city, state, zipCode, country, password)
        {
            Pets = new List<Pet>();
            Bookings = new List<DateTime>();
        }
        public List<Pet>? Pets { get; set; }
        public List<DateTime>? Bookings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Pets == null || Pets.Count == 0)
            {
                yield return new ValidationResult(
                    "Customer must have at least one pet.",
                    new[] { nameof(Pets) });
            }
        }
}
