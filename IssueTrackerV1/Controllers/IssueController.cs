using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;
using IssueTrackerV1.ViewModels;

namespace IssueTrackerV1.Controllers
{
    public class IssueController : Controller
    {
        public ViewResult Index()
        {
            var issue = GetIssues();

            return View(issue);
        }

        private IEnumerable<Issue> GetIssues()
        {
            return new List<Issue>
            {
                new Issue {Id = 1, Name = "To-Do-1"},
                new Issue {Id = 2, Name = "To-Do-2"}
            };
        }
    }
}