using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TakeGithubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubRepoController : ControllerBase
    {
        // GET: api/<GithubRepositoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GithubRepositoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
