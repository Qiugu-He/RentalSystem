using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {   
            var users = GetUsers();
            return View(users);
        }


        public ActionResult Details(int id)
        {
            var user = GetUsers().SingleOrDefault(c => c.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        private IEnumerable <User> GetUsers()
        {
            return new List<User>
            {
                new User {Id = 1, Name = "UserName1"},
                new User {Id = 2, Name = "UserName2"}
            };
        }

    }
}