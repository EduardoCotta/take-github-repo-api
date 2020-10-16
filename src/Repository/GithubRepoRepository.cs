using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TakeGithubAPI.Models;
using TakeGithubAPI.Models.Repository;
using TakeGithubAPI.Utils;

namespace TakeGithubAPI.Repository
{
    public class GithubRepoRepository : IGithubRepoRepository
    {
        private readonly IApplicationEnviroment _applicationEnviroment;
        private readonly string BASE_URL;

        public GithubRepoRepository(IApplicationEnviroment applicationEnviroment)
        {
            _applicationEnviroment = applicationEnviroment;
            BASE_URL = _applicationEnviroment.GetGithubAPIReposBaseURL();
        }

        private HttpClient ConfigureHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TakeGithubAPI", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _applicationEnviroment.GetGithubAPIAccessToken());

            return client;
        }

        public async Task<IEnumerable<GithubRepo>> GetAllGithubRepositoriesByOrganizationNameAsync(string organizationName)
        {
            IEnumerable<GithubRepo> githubRepos;
            using HttpClient client = ConfigureHttpClient();

            string url = Regex.Replace(BASE_URL, "ORGANIZATION_NAME", organizationName);
            
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                githubRepos = JsonSerializer.Deserialize<List<GithubRepo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            }

            return githubRepos;
        }
    }
}
