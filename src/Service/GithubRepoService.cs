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
        async Task<IEnumerable<GithubRepoDTO>> IGithubRepoService.GetAllGithubRepositoriesByOrganizationAsync(string organizationName)
        {
            if (string.IsNullOrWhiteSpace(organizationName))
            {
                throw new ArgumentException("O nome da organização não pode ser nulo.");
            }

            var githubRepos = await _githubRepoRepository.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName);
                
            return githubRepos.Select(repo => new GithubRepoDTO(repo));
        }

        async Task<IEnumerable<GithubRepoDTO>> IGithubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganizationAsync(string organizationName, Language language, int numberOfRepositories)
        {
            VerifyRequest(organizationName, numberOfRepositories);

            var result = await _githubRepoRepository.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName);

            Func<Models.GithubRepo, bool> filterByRepositoryLanguage = FilterRepositoryLanguage(language);
            return
                result
                .Where(repo => !string.IsNullOrEmpty(repo.LanguageName))
                .Where(filterByRepositoryLanguage)
                .OrderBy(repo => repo.CreationDate)
                .Take(numberOfRepositories)
                .Select(repo => new GithubRepoDTO(repo));

            
        }
        private Func<Models.GithubRepo, bool> FilterRepositoryLanguage(Language language)
        {
            return repo => repo.LanguageType == language || language == Language.AnyLanguage;
        }

        public void VerifyRequest(string organizationName, int numberOfRepositories)
        {
            if (string.IsNullOrWhiteSpace(organizationName))
            {
                throw new ArgumentException("O nome da organização não pode ser nulo.");
            }

            if (numberOfRepositories == default(int))
            {
                throw new ArgumentException("O número de repositório não pode ser igual a 0.");
            }
        }
    }
}
