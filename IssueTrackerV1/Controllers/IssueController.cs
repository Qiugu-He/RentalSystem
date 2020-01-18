using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;
using IssueTrackerV1.ViewModels;

namespace IssueTrackerV1.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationDbContext _context;

        public IssueController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var issues = _context.Issues.Include(m => m.Genre).ToList();


            return View(issues);
        }

        public ActionResult Details(int id)
        {
            var issue = _context.Issues.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (issue == null)
            {
                return HttpNotFound();
            }

            return View(issue);

        }
    }
}