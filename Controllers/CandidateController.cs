using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;
using CandidateHubApi.Data;
using CandidateHubApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateHubApi.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly CandidateDataContext dataContext;

        public CandidateController(CandidateDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dataContext.Candidates.ToListAsync());
        }

        // GET api/values/5
        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult>  Get([FromRoute] string email)
        {
            var contact = await dataContext.Candidates.Where(d => d.Email == email).FirstOrDefaultAsync();

            if (contact != null)
            {
                return Ok(contact);


            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddCandidatePost([FromBody] Candidate data)
        {
            var candidate= await dataContext.Candidates.Where(d=>d.Email==data.Email).FirstOrDefaultAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (candidate != null)
            {

                candidate.FirstName = data.FirstName;
                candidate.LastName = data.LastName;
                candidate.PhoneNumber = data.PhoneNumber;
                candidate.Email = data.Email;
                candidate.LinkedInProfileUrl = data.LinkedInProfileUrl;
                candidate.GithubProfileUrl = data.GithubProfileUrl;
                candidate.Comment = data.Comment;
                candidate.TimeIntervalcall = data.TimeIntervalcall;
                await dataContext.SaveChangesAsync();

                return Ok(candidate);


            }
          

            var candidatesave = new Candidate()
            {
                Id = Guid.NewGuid(),
             FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Email = data.Email,
            LinkedInProfileUrl = data.LinkedInProfileUrl,
            GithubProfileUrl = data.GithubProfileUrl,
            Comment = data.Comment,
            TimeIntervalcall = data.TimeIntervalcall,

           };

            await dataContext.Candidates.AddAsync(candidatesave);
            await dataContext.SaveChangesAsync();

            return Ok(candidate);
        }

        [HttpPut]
        [Route("{email}")]
        public async Task<IActionResult> UpadateContact([FromRoute] string email, [FromBody] Candidate data)
        {
            var candidate = await dataContext.Candidates.Where(d => d.Email == email).FirstOrDefaultAsync();

            if (candidate != null)
            {

                candidate.FirstName = data.FirstName;
                candidate.LastName = data.LastName;
                candidate.PhoneNumber = data.PhoneNumber;
                candidate.Email = data.Email;
                candidate.LinkedInProfileUrl = data.LinkedInProfileUrl;
                candidate.GithubProfileUrl = data.GithubProfileUrl;
                candidate.Comment = data.Comment;
                candidate.TimeIntervalcall = data.TimeIntervalcall;
                await dataContext.SaveChangesAsync();

                return Ok(candidate);


            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{email}")]
        public async Task<IActionResult>Delete(string email)
        {
            var candidate = await dataContext.Candidates.Where(d => d.Email == email).FirstOrDefaultAsync();

            if (candidate != null)
            {
                dataContext.Remove(candidate);
                await dataContext.SaveChangesAsync();
                return Ok(candidate);


            }
            return NotFound();
        }

    }
}

