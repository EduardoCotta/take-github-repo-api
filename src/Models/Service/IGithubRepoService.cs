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
        IEnumerable<GithubRepoDTO> GetAllGithubRepositoriesByOrganization(string organizationName);
        IEnumerable<GithubRepoDTO> GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization(string organizationName, Language language, int numberOfRepositories);
    }
}
