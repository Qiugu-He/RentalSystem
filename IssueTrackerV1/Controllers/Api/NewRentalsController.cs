using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IssueTrackerV1.Dtos;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var user = _context.Users.Single(
                u=> u.Id == newRental.UserId);

            var issues = _context.Issues.Where(
                i => newRental.IssueIds.Contains(i.Id)).ToList();


            foreach (var issue in issues)
            {
                if (issue.NumberAvaliable == 0)
                    return BadRequest("This issue is not available");

                issue.NumberAvaliable--;

                var rental = new Rental
                {
                    User = user,
                    Issue = issue,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();

        }
    }
}
