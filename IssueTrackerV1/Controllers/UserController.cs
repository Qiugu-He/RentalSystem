using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;

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
    }
}