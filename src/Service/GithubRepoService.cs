using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.DTO;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Models.Repository;
using TakeGithubAPI.Models.Service;

namespace TakeGithubAPI.Service
{
    public class GithubRepoService : IGithubRepoService
    {
        private readonly IGithubRepoRepository _githubRepoRepository;
        public GithubRepoService(IGithubRepoRepository githubRepoRepository)
        {
            _githubRepoRepository = githubRepoRepository;
        }
        List<GithubRepoDTO> IGithubRepoService.GetAllGithubRepositoriesByOrganization(string organizationName)
        {
            throw new NotImplementedException();
        }

        List<GithubRepoDTO> IGithubRepoService.GetNGithubRepositoriesByLanguageAndOrganization(string organizationName, Language language, int numberOfRepositories)
        {
            throw new NotImplementedException();
        }
    }
}
