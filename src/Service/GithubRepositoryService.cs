using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.DTO;
using TakeGithubAPI.Models.Service;

namespace TakeGithubAPI.Service
{
    public class GithubRepositoryService : IGithubRepositoryService
    {
        List<GithubRepositoryDTO> IGithubRepositoryService.GetAllGithubRepositories()
        {
            throw new NotImplementedException();
        }

        List<GithubRepositoryDTO> IGithubRepositoryService.GetFirstFiveGithubRepositoriesLanguageCSharp()
        {
            throw new NotImplementedException();
        }
    }
}
