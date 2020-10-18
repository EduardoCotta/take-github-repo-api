using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Enums.Util;
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
        public async Task<IActionResult> GetAsync(string organizationName, [FromQuery] int amount = 500, string languageName = "")
        {
            try
            {
                Language language = EnumParser.ParseOrDefault<Language>(languageName);
                var githubRepos = await _githubRepoService.GetGithubRepositoriesByOrganizationFilteredOrderedByFirstCreatedAsync(organizationName, language, amount);
                return Ok(githubRepos);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
