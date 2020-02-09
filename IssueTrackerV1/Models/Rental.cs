using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTrackerV1.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Issue Issue { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}