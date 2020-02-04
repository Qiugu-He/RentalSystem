using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        // [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}