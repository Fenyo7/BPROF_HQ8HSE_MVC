﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rental.Data
{
    class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public VideoGame Game { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameRef { get; set; }

        [NotMapped]
        public Person Person { get; set; }
        [ForeignKey(nameof(Person))]
        public int PersonRef { get; set; }

        [Required]
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        //Fine calculation: after 30 days, $2 for each day, can be calculated after getting a return date
        public int DelayFine { get
            {
                int fine = (ReturnDate == null) ? 0 : (ReturnDate.DayOfYear - RentDate.DayOfYear + ((ReturnDate.Year - RentDate.Year) * 365) - 30) * 2;
                if(fine > 0)
                {
                    return fine;
                }
                else
                {
                    return 0;
                }
            } }

        [NotMapped]
        public string AllData { get
            {
                string helper;
                if(ReturnDate != null)
                {
                    helper = $"and returned it on {ReturnDate}";
                    if(DelayFine > 0)
                    {
                        helper += $", with a fine of ${DelayFine}.";
                    }
                    else
                    {
                        helper += " with no fine.";
                    }
                }
                else
                {
                    helper = "and have not returned it yet.";
                }
                return $"[Id: {Id}] > ({Game.Name}) was rented by ({Person.Name}) on {RentDate} {helper}";
            } }
    }
}
