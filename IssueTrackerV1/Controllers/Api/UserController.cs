using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
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
        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users.ToList().Select(Mapper.Map<User, UserDto>);
        }

        // GET /api/users/1
        public UserDto GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<User, UserDto>(user);
        }

        // POST /api/users
        [HttpPost]
        public UserDto CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;

            return userDto;
        }

        //PUT /api/users/1
        [HttpPut]
        public void UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode. NotFound);

            Mapper.Map(userDto, userInDb);

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
