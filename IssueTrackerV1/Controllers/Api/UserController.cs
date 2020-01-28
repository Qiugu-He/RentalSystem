using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Controllers.Api
{
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/users
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        // GET /api/users/1
        public User GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return user;
        }

        // POST /api/users
        [HttpPost]
        public User CreateUser(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        //PUT /api/users/1
        [HttpPut]
        public void UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode. NotFound);

            userInDb.Name = user.Name;
            userInDb.Birthdate = user.Birthdate;
            userInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
            userInDb.MembershipTypeId = user.MembershipTypeId;

            _context.SaveChanges();
        }

        //DELETE /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }
    }
}
