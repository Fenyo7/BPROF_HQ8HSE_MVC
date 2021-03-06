﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rent.Data
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public Person()
        {
            Rentals = new HashSet<Rental>();
        }

        [NotMapped]
        public string AllData => $"[Id: {Id}] > Name : {Name}, age: {DateTime.Now.Year - BirthDate.Year}";

        public override string ToString()
        {
            return AllData;
        }
    }
}
