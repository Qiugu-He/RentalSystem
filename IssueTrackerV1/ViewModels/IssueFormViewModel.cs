using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.ViewModels
{
    public class IssueFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Issue Issue { get; set; }

        public string Title
        {
            get
            {
                if (Issue != null && Issue.Id != 0)
                    return "Edit Issue";

                return "New Issue";
            }
        }
    }
}