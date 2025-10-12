using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public DateOnly? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [NotMapped]
        public string Address => $"{StreetNumber} {StreetName}, {City}, {State}, {ZipCode}, {Country}";
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? StreetNumber { get; set; }
        public string? Password { get; set; }
        public string? StreetName { get; set; }
        public Person(int id, string firstName, string lastName, DateOnly dateOfBirth, string email, string phoneNumber, string streetNumber, string streetName, string city, string state, int zipCode, string country, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            StreetNumber = streetNumber;
            StreetName = streetName;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Password = password;
        }

    }
}
