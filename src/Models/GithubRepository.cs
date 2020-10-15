using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeGithubAPI.Models
{
    public class GithubRepository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }

        public DateTime CreationDate { get; set; }

        public string Language { get; set; }
    }
}
