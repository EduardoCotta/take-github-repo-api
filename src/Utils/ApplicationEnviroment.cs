using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeGithubAPI.Utils
{
    public class ApplicationEnviroment : IApplicationEnviroment
    {
        private readonly IConfiguration _config;

        public ApplicationEnviroment(IConfiguration config)
        {
            _config = config;
        }

        public string GetGithubAPIReposBaseURL()
        {
            return _config.GetValue<string>("Endpoints:GITHUB-API-REPOS-BASE-URL");
        }

        public string GetGithubAPIAccessToken()
        {
            return _config.GetValue<string>("GithubPersonalToken");
        }

    }
}
