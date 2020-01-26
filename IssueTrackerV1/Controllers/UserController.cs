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
                User = new User(),
                MembershipTypes = membershipTypes
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("UserForm", viewModel);
            }

            if (user.Id == 0)
                _context.Users.Add(user);
            else
            {
                var userInDb = _context.Users.Single(u => u.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.Birthdate = user.Birthdate;
                userInDb.MembershipTypeId = user.MembershipTypeId;
                userInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
            }

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