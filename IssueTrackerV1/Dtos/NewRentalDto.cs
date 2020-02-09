using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTrackerV1.Dtos
{
    public class NewRentalDto
    {
        public int UserId { get; set; }
        public List<int> IssueIds { get; set; }
    }
}