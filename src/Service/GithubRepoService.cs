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
        async Task<IEnumerable<GithubRepoDTO>> IGithubRepoService.GetAllGithubRepositoriesByOrganization(string organizationName)
        {
            if (string.IsNullOrEmpty(organizationName))
            {
                throw new ArgumentException("O nome da organização não pode ser nulo.");
            }

            var githubRepos = await _githubRepoRepository.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName);
                
            return githubRepos.Select(repo => new GithubRepoDTO(repo));
        }

        async Task<IEnumerable<GithubRepoDTO>> IGithubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization(string organizationName, Language language, int numberOfRepositories)
        {
            verifyRequest(organizationName, numberOfRepositories);

            var result = await _githubRepoRepository.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName);

            return
                result
                .Where(repo => !string.IsNullOrEmpty(repo.LanguageName))
                .Where(repo => repo.LanguageType == language)
                .OrderBy(repo => repo.CreationDate)
                .Take(numberOfRepositories)
                .Select(repo => new GithubRepoDTO(repo));
        }

        public void verifyRequest(string organizationName, int numberOfRepositories)
        {
            if (string.IsNullOrEmpty(organizationName))
            {
                throw new ArgumentException("O nome da organização não pode ser nulo.");
            }

            if (numberOfRepositories == 0)
            {
                throw new ArgumentException("O número de repositório não pode ser igual a 0.");
            }
        }
    }
}
