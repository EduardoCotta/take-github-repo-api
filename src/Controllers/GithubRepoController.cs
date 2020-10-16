using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Models.Service;

namespace TakeGithubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubRepoController : ControllerBase
    {
        private readonly IGithubRepoService _githubRepoService;
        public GithubRepoController(IGithubRepoService githubRepoService)
        {
            _githubRepoService = githubRepoService;
        }
        [HttpGet]
        [Route("{organizationName}")]
        public async Task<IActionResult> GetAsync(string organizationName)
        {
            try
            {
                var githubRepos = await _githubRepoService.GetAllGithubRepositoriesByOrganizationAsync(organizationName);
                return Ok(githubRepos);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet]
        [Route("{organizationName}")]
        public async Task<IActionResult> GetNFirstCreatedGithubRepositoriesByOrganizationMadeInCSharp(string organizationName, [FromQuery] int amount)
        {
            try
            {
                var githubRepos = await _githubRepoService.GetNFirstCreatedGithubRepositoriesByLanguageAndOrganizationAsync(organizationName, Language.CSharp, amount);
                return Ok(githubRepos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
