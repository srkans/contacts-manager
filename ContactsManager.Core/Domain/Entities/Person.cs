﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManager.Core.Domain.Entities
{
    public class Person //Domain model class
    {
        [Key]
        public Guid PersonID { get; set; }
        [StringLength(40)] //nvarchar(40)
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(10)]
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; } //foreign key for country table

        [StringLength(200)]
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country? Country { get; set; }

        public override string ToString()
        {
            return $"Person Id : {PersonID}, Person Name : {Name}";
        }

    }
}
