using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.DTO;
using TakeGithubAPI.Enums;

namespace TakeGithubAPI.Models.Service
{
    public interface IGithubRepoService
    {
        Task<IEnumerable<GithubRepoDTO>> GetAllGithubRepositoriesByOrganizationAsync(string organizationName);
        Task<IEnumerable<GithubRepoDTO>> GetGithubRepositoriesByOrganizationFilteredOrderedByFirstCreatedAsync(string organizationName, Language language, int numberOfRepositories);
    }
}
