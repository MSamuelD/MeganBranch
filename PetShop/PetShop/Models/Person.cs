using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Person : System.ComponentModel.IDataErrorInfo
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
        public Person()
        {

        }
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

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            result = "You must enter a first name";
                            
                        }
                        break;

                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName)
                        {
                            result = "You must enter a last name";
                        }
                        break;

                    case "DateOfBirth":
                        if (DateOfBirth == null || DateOfBirth == default)
                        {
                            result = "Please enter a DateOfBirth.";
                        }

                        else if (DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
                        {
                            result = "DOB must not be in the future.";
                        }

                        else if (DateOfBirth < (DateOnly.FromDateTime(DateTime.Now)).AddYears(-110))
                        {
                            result = "DOB cannot be from over 110 years ago.";
                        }

                        else if (DateOfBirth > (DateOnly.FromDateTime(DateTime.Now).AddYears(-18)))
                        {
                            result = "Person must not be under 18.";
                        }
                        break;

                    case "Email":

                        if (string.IsNullOrWhiteSpace(Email) || (!Email.Contains('@')))
                        {
                            result = "Email must not be empty and must contain '@' symbol.";

                        }
                        break;

                    case "PhoneNumber":

                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                        {
                           result= "You must enter a phone number.";
                        }

                        else  if (!PhoneNumber.All(char.IsDigit) || PhoneNumber.Length != 10)
                        {
                            result = "Phone number must be numeric and contain 10 digits.";
                        }
                        break;

                    case "StreetNumber":
                        if (!StreetNumber.All(char.IsDigit) || string.IsNullOrWhiteSpace(StreetNumber))
                        {
                           result="Street number must be non-empty and numeric.";
                        }
                        break;

                    case "StreetName":
                        if (StreetName.Any(char.IsDigit) || string.IsNullOrWhiteSpace(StreetName))
                        {
                            result="Street Name must be non empty and must not contain numbers.";
                        }
                        break;

                    case "City":
                        if (City.Any(char.IsDigit) || string.IsNullOrWhiteSpace(City))
                        {
                            result = "City must not contain numbers and must not be empty.";
                        }
                        break;

                    case "State":
                        if (State.Any(char.IsDigit) || string.IsNullOrWhiteSpace(State))
                        {
                            result = "State must not contain numbers and must not be empty.";
                        }
                        break;

                    case "ZipCode":
                        if (ZipCode == null)
                        {
                            result = "Zip code must not be empty.";
                        }
                        break;

                    case "Country":
                        if ((string.IsNullOrWhiteSpace(Country) || Country.Any(char.IsDigit)))
                        {
                            result = ("Country must not be empty or contain numbers.";
                        }
                        break;

                    default:
                        break;
                        


                }

                return result;


            }
                
            }

    }



}
