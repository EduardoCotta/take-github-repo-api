using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.Models;

namespace TakeGithubAPI.DTO
{
    public class GithubRepoDTO
    {
        public GithubRepoDTO()
        {
        }
        public GithubRepoDTO(GithubRepo githubRepo)
        {
            Name = githubRepo.Name;
            Description = githubRepo.Description;
            Owner = new OwnerDTO(githubRepo.Owner);
            LanguageName = githubRepo.LanguageName;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public OwnerDTO Owner { get; set; }
        public string LanguageName { get; set; }
    }
}
