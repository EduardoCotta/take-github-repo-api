using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeGithubAPI.Models.Repository
{
    public interface IGithubRepoRepository
    {
        IEnumerable<GithubRepo> GetAllGithubRepositoriesByOrganizationName(string organizationName);
    }
}
