﻿using ContactsManager.Core.Domain.Entities;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents the DTO class that contains the person details to update
    /// </summary>
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage = "Person ID can't be blank")]
        public Guid PersonID { get; set; }

        [Required(ErrorMessage = "Person name can't be blank")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be a valid email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        [Required(ErrorMessage = "Please select a country")]
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the current object of PersonUpdateRequest into a new object of Person type
        /// </summary>
        /// <returns>Returns Person object</returns>
        public Person ToPerson()
        {
            return new Person() {PersonID =PersonID, Name = Name, Email = Email, DateOfBirth = DateOfBirth, Gender = Gender.ToString(), CountryID = CountryID, Address = Address, ReceiveNewsLetters = ReceiveNewsLetters };
        }
    }
}
