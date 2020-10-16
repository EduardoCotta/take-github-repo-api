using System.Text.Json.Serialization;

namespace TakeGithubAPI.Models
{
    public class Owner
    {
        [JsonPropertyName("avatar_url")]
        public string AvatarURL { get; set; }
        public string Login { get; set; }
    }
}