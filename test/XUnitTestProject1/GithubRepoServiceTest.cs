using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.DTO;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Models;
using TakeGithubAPI.Models.Repository;
using TakeGithubAPI.Models.Service;
using TakeGithubAPI.Service;
using Xunit;

namespace TakeGithubAPITest
{
    public class GithubRepoServiceTest
    {
        private const string ORGANIZATION_NAME = "takenet";
        private readonly IGithubRepoService _githubRepoService;
        private readonly Mock<IGithubRepoRepository> _githubRepoRepository = new Mock<IGithubRepoRepository>();

        #region.: Test Initialize :.
        public GithubRepoServiceTest()
        {
            _githubRepoService = new GithubRepoService(_githubRepoRepository.Object);
        }
        #endregion

        #region.: Tests :.
        [Fact]
        public async Task GetAllRepositoriesOfTake_Success()
        {
            #region .: Arrange :.
            const string organizationName = ORGANIZATION_NAME;
            var githubRepos = GithubReposBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName)).ReturnsAsync(githubRepos);
            #endregion

            #region .: Act :.
            var result = await _githubRepoService.GetAllGithubRepositoriesByOrganizationAsync(organizationName);
            #endregion
            #region .: Assert :.
            Assert.All(result, item => Assert.Contains(organizationName, item.Owner.Name));
            Assert.IsAssignableFrom<IEnumerable<GithubRepoDTO>>(result);
            #endregion

        }


        [Fact]
        public void GetAllRepositoriesOfTake_ThrowsArgumentExceptionAsync()
        {
            #region .: Arrange :.
            string organizationName = string.Empty;
            var githubRepos = GithubReposBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName)).ReturnsAsync(githubRepos);
            #endregion

            #region .: Act :.
            Task result() => _githubRepoService.GetAllGithubRepositoriesByOrganizationAsync(organizationName);
            #endregion
            #region .: Assert :.

            Assert.ThrowsAsync<ArgumentException>(result);
            #endregion

        }

        [Fact]
        public async Task GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization_Success()
        {
            #region .: Arrange :.
            const string organizationName = ORGANIZATION_NAME;
            const Language language = Language.CSharp;
            const int numberOfRepositories = 2;
            var githubRepos = GithubReposBuilder();
            var expectedGithubRepos = GithubReposDTOFilteredBuilder();

            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName)).ReturnsAsync(githubRepos);
            #endregion

            #region .: Act :.
            var result = await _githubRepoService.GetGithubRepositoriesByOrganizationFilteredOrderedByFirstCreatedAsync(organizationName, language, numberOfRepositories);
            #endregion
            #region .: Assert :.

            Assert.All(result, item => Assert.Contains(organizationName, item.Owner.Name));
            Assert.Equal(expectedGithubRepos.ElementAt(0).Name, result.ElementAt(0).Name);
            Assert.Equal(expectedGithubRepos.ElementAt(1).Name, result.ElementAt(1).Name);
            Assert.IsAssignableFrom<IEnumerable<GithubRepoDTO>>(result);
            #endregion

        }


        [Fact]
        public void GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization_ThrowsArgumentException()
        {
            #region .: Arrange :.
            string organizationName = string.Empty;
            const Language language = Language.CSharp;
            int numberOfRepositories = default(int);
            var githubRepos = GithubReposBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationNameAsync(organizationName)).ReturnsAsync(githubRepos);
            #endregion

            #region .: Act :.
            Task result () => _githubRepoService.GetGithubRepositoriesByOrganizationFilteredOrderedByFirstCreatedAsync(organizationName, language, numberOfRepositories);
            #endregion
            #region .: Assert :.

            Assert.ThrowsAsync<ArgumentException>(result);
            #endregion

        }

        #endregion

        #region.: Builders :.
        private IEnumerable<GithubRepo> GithubReposBuilder()
        {
            return new List<GithubRepo>
            {
                new GithubRepo
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep2",
                    LanguageName = "C#",
                    CreationDate = DateTime.Now.AddDays(-3)
                },
                new GithubRepo
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep3",
                    LanguageName = "C#",
                    CreationDate = DateTime.Now.AddDays(-1)
                },
                new GithubRepo
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep4",
                    LanguageName = "Java"
                },
                new GithubRepo
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep5",
                    LanguageName = "Javascript"
                },
                new GithubRepo
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep1",
                    LanguageName = "C#",
                    CreationDate = DateTime.Now.AddDays(-365)
                },
            };
        }
        
        private IEnumerable<GithubRepoDTO> GithubReposDTOBuilder()
        {
            return new List<GithubRepoDTO>
            {
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep1"
                },
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep2"
                },
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep3"
                },
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep4"
                },
            };
        }


        private IEnumerable<GithubRepoDTO> GithubReposDTOFilteredBuilder()
        {
            return new List<GithubRepoDTO>
            {
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep1"
                },
                new GithubRepoDTO
                {
                    Owner = new OwnerDTO(TakeOwnerBuilder()),
                    Name = "Rep2"
                },
            };
        }
        private Owner TakeOwnerBuilder()
        {
            return new Owner
            {
                Login = ORGANIZATION_NAME,
                AvatarURL = "url_teste.com"
            };
        }
        private Owner OtherOwnerBuilder()
        {
            return new Owner
            {
                Login = "other_company",
                AvatarURL = "url_teste1.com"
            };
        }
        #endregion
    }
}
