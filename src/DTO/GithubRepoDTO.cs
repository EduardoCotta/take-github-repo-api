using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.Models;

namespace TakeGithubAPI.DTO
{
    public class GithubRepoDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }
    }
}
