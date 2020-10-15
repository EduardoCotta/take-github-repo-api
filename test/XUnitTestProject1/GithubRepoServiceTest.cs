using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetAllRepositoriesOfTake_Success()
        {
            #region .: Arrange :.
            const string organizationName = "takenet";
            var githubRepos = GithubReposBuilder();
            var expectedGithubRepos = GithubReposDTOBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationName(organizationName)).Returns(githubRepos);
            #endregion

            #region .: Act :.
            var result = _githubRepoService.GetAllGithubRepositoriesByOrganization(organizationName);
            #endregion
            #region .: Assert :.
            Assert.All(result, item => Assert.Contains(organizationName, item.Name));
            Assert.IsType<List<GithubRepoDTO>>(result);
            #endregion

        }


        [Fact]
        public void GetAllRepositoriesOfTake_ThrowsArgumentException()
        {
            #region .: Arrange :.
            const string organizationName = "";
            var githubRepos = GithubReposBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationName(organizationName)).Returns(githubRepos);
            #endregion

            #region .: Act :.
            Action act = () =>  _githubRepoService.GetAllGithubRepositoriesByOrganization(organizationName);
            #endregion
            #region .: Assert :.
            
            Assert.Throws<ArgumentException>(act);
            #endregion

        }

        [Fact]
        public void GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization_Success()
        {
            #region .: Arrange :.
            const string organizationName = "takenet";
            const Language language = Language.CSharp;
            const int numberOfRepositories = 2;
            var githubRepos = GithubReposBuilder();
            var expectedGithubRepos = GithubReposDTOFilteredBuilder();

            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationName(organizationName)).Returns(githubRepos);
            #endregion

            #region .: Act :.
            var result = _githubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization(organizationName, language, numberOfRepositories);
            #endregion
            #region .: Assert :.

            Assert.All(result, item => Assert.Contains(organizationName, item.Name));
            Assert.Equal(result.ElementAt(0).Name, expectedGithubRepos.ElementAt(0).Name);
            Assert.Equal(result.ElementAt(1).Name, expectedGithubRepos.ElementAt(1).Name);
            Assert.IsType<List<GithubRepoDTO>>(result);
            #endregion

        }


        [Fact]
        public void GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization_ThrowsArgumentException()
        {
            #region .: Arrange :.
            const string organizationName = "";
            const Language language = Language.CSharp;
            const int numberOfRepositories = 0;
            var githubRepos = GithubReposBuilder();
            _githubRepoRepository.Setup(x => x.GetAllGithubRepositoriesByOrganizationName(organizationName)).Returns(githubRepos);
            #endregion

            #region .: Act :.
            Action act = () => _githubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization(organizationName, language, numberOfRepositories);
            #endregion
            #region .: Assert :.

            Assert.Throws<ArgumentException>(act);
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
                    Name = "Rep1",
                    LanguageName = "C#",
                    CreationDate = DateTime.Now.AddDays(-4)
                },
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
            };
        }
        
        private IEnumerable<GithubRepoDTO> GithubReposDTOBuilder()
        {
            return new List<GithubRepoDTO>
            {
                new GithubRepoDTO
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep1"
                },
                new GithubRepoDTO
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep2"
                },
                new GithubRepoDTO
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep3"
                },
                new GithubRepoDTO
                {
                    Owner = TakeOwnerBuilder(),
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
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep1"
                },
                new GithubRepoDTO
                {
                    Owner = TakeOwnerBuilder(),
                    Name = "Rep2"
                },
            };
        }
        private Owner TakeOwnerBuilder()
        {
            return new Owner
            {
                Name = "takenet",
                AvatarURL = "url_teste.com"
            };
        }
        private Owner OtherOwnerBuilder()
        {
            return new Owner
            {
                Name = "other_company",
                AvatarURL = "url_teste1.com"
            };
        }
        #endregion
    }
}
