using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public IEnumerable<IssueDto> GetIssues(string query = null)
        {
            var issuesQuery = _context.Issues
                .Include(m =>m.Genre)
                .Where(m => m.NumberAvaliable >0);

            if(!String.IsNullOrWhiteSpace(query))
                issuesQuery = issuesQuery.Where(m => m.Name.Contains(query));
                
            
            return issuesQuery
                .ToList()
                .Select(Mapper.Map<Issue, IssueDto>);
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
        public IHttpActionResult CreateIssue(IssueDto issueDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var issueInDb = Mapper.Map<IssueDto, Issue>(issueDto);
            _context.Issues.Add(issueInDb);
            _context.SaveChanges();

            issueDto.Id = issueInDb.Id;
            return Created(new Uri(Request.RequestUri + "/" + issueInDb.Id), issueDto);
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