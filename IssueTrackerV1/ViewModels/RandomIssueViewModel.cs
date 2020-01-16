using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.ViewModels
{
    public class RandomIssueViewModel
    {
        public Issue Issue { get; set; }
        public List<User> Users { get; set; }
    }
}