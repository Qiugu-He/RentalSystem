using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.ViewModels
{
    public class IssueFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStack { get; set; }


        public string Title
        {
            get { return Id != 0 ? "Edit Issue" : "New Issue"; }
        }

        public IssueFormViewModel()
        {
            Id = 0;
        }

        public IssueFormViewModel(Issue issue)
        {
            Id = issue.Id;
            Name = issue.Name;
            ReleaseDate = issue.ReleaseDate;
            NumberInStack = issue.NumberInStack;
            GenreId = issue.GenreId;
        }
    }
}