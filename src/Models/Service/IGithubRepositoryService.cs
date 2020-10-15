using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.DTO;

namespace TakeGithubAPI.Models.Service
{
    public interface IGithubRepositoryService
    {
        List<GithubRepositoryDTO> GetAllGithubRepositories();
        List<GithubRepositoryDTO> GetFirstFiveGithubRepositoriesLanguageCSharp();
    }
}
