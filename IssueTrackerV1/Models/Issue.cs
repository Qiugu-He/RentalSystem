using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace IssueTrackerV1.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }

        public byte NumberInStack { get; set; }
    }
}