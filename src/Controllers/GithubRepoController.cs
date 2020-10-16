using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Models.Service;

namespace TakeGithubAPI.Controllers
{
    [Route("api/githubrepo")]
    [ApiController]
    public class GithubRepoController : ControllerBase
    {
        private readonly IGithubRepoService _githubRepoService;
        public GithubRepoController(IGithubRepoService githubRepoService)
        {
            _githubRepoService = githubRepoService;
        }
        [HttpGet]
        [Route("{organizationName}/all")]
        public async Task<IActionResult> GetAsync(string organizationName)
        {
            try
            {
                var githubRepos = await _githubRepoService.GetAllGithubRepositoriesByOrganization(organizationName);
                return Ok(githubRepos);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{organizationName}/{numberOfRepositories}")]
        public async Task<IActionResult> GetNFirstCreatedGithubRepositoriesByOrganizationMadeInCSharp(string organizationName, int numberOfRepositories)
        {
            try
            {
                var githubRepos = await _githubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganization(organizationName, Language.CSharp, numberOfRepositories);
                return Ok(githubRepos);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
