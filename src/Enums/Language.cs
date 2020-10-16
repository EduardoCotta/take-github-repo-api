using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TakeGithubAPI.Enums
{
    public enum Language
    {
        [Description("C#")]
        CSharp,
        [Description("Java")]
        Java,
        [Description("Javascript")]
        Javascript,
        [Description("TypeScript")]
        TypeScript,
        [Description("Shell")]
        Shell,
        [Description("PHP")]
        PHP,
        [Description("CSS")]
        CSS,
        [Description("HTML")]
        HTML,
        [Description(".*")]
        AnyLanguage

    }
}
