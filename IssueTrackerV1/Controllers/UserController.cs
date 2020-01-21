using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;
using IssueTrackerV1.ViewModels;

namespace IssueTrackerV1.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new UserFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }

        public ViewResult Index()
        {   
            var users = _context.Users.Include(c => c.MembershipType).ToList();
            return View(users);
        }


        public ActionResult Details(int id)
        {
            var user = _context.Users.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel
            {
                User = user,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("UserForm", viewModel);
        }
    }
}