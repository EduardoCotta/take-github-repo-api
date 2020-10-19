using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Enums.Util;

namespace TakeGithubAPI.Models
{
    public class GithubRepo
    {
        public string Name { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreationDate { get; set; }
        [JsonPropertyName("language")]
        public string LanguageName { get; set; }
        public Language LanguageType => EnumParser.ParseOrDefault<Language>(LanguageName);
    }
}
