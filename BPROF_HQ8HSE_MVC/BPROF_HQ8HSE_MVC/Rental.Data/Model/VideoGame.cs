using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rental.Data
{
    class VideoGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int Rating { get;set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public VideoGame()
        {
            Rentals = new HashSet<Rental>();
        }
    }
}
