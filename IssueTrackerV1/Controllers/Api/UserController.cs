using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

using System.Data.Entity;

using IssueTrackerV1.Dtos;
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
        public IHttpActionResult GetUsers(string query = null)
        {
            var usersQuery = _context.Users
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                usersQuery = usersQuery.Where(c => c.Name.Contains(query));

            var userDtos = usersQuery
                .ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(userDtos);
        }

        // GET /api/users/1
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<User, UserDto>(user));
        }

        // POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;

            return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
        }

        //PUT /api/users/1
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                return NotFound();

            Mapper.Map(userDto, userInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/users/1
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userInDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (userInDb == null)
                return NotFound();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
