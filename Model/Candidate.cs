using System;
using System.ComponentModel.DataAnnotations;

namespace CandidateHubApi.Model
{
    public class Candidate
    {

        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string TimeIntervalcall { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string GithubProfileUrl { get; set; }

        [Required]
        public string Comment { get; set; }

       

    }
}

