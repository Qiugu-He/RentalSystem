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
        // GET: Issue
        public ActionResult Random()
        {
            var issue = new Issue() {Name = "ToDo1"};

            var users = new List<User>
            {
                new User {Name = "User 1"},
                new User {Name = "User 2"}
                
            };

            var viewModel = new RandomIssueViewModel
            {
                Issue = issue,
                Users = users
            };

            return View(viewModel);
        }
    }
}