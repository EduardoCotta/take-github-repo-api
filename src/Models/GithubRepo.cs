using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.Enums;
using TakeGithubAPI.Enums.Util;

namespace TakeGithubAPI.Models
{
    public class GithubRepo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }

        public DateTime CreationDate { get; set; }

        public string LanguageName { get; set; }

        private Language language;
        public Language Language { get { return language; } private set => language = EnumParser.ParseOrDefault<Language>(LanguageName); }
    }
}
