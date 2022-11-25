using System;
using CandidateHubApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CandidateHubApi.Data
{
    public class CandidateDataContext : DbContext
    {
       

        public CandidateDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
    }
}

