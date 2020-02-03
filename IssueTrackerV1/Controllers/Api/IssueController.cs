using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using IssueTrackerV1.Dtos;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.Controllers.Api
{
    public class IssueController : ApiController
    {
        private ApplicationDbContext _context;

        public IssueController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/Issue
        public IEnumerable<IssueDto> GetIssues()
        {
            return _context.Issues.ToList().Select(Mapper.Map<Issue, IssueDto>);
        }


        //GET/Issue/1
        public IHttpActionResult GetIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(c => c.Id == id);

            if (issue == null)
                return NotFound();

            return Ok(Mapper.Map<Issue, IssueDto>(issue));
        }

        //Post
        [HttpPost]
        public IHttpActionResult CreateIssue(IssueDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<IssueDto, Issue>(movieDto);
            _context.Issues.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/issue
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, IssueDto issueDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var issueInDb = _context.Issues.SingleOrDefault(c => c.Id == id);

            if (issueInDb == null)
                return NotFound();

            Mapper.Map(issueDto, issueInDb);

            _context.SaveChanges();

            return Ok();
        }

        //Delete /api/issue/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var issueInDb = _context.Issues.SingleOrDefault(c => c.Id == id);

            if (issueInDb == null)
                return NotFound();

            _context.Issues.Remove(issueInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}