using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeGithubAPI.Utils
{
    public interface IApplicationEnviroment
    {
        string GetGithubAPIReposBaseURL();
        string GetGithubAPIAccessToken();
    }
}
