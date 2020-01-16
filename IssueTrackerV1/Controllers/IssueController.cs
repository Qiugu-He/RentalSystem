using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult Random()
        {
            var issue = new Issue() {Name = "ToDo1"};

            return View(issue);
        }
    }
}