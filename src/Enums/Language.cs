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
        CSharp = 0,
        [Description("Java")]
        Java = 1,
        [Description("Javascript")]
        Javascript = 2,
        [Description("TypeScript")]
        TypeScript = 3,
        [Description("Shell")]
        Shell = 4,
        [Description("PHP")]
        PHP = 5,
        [Description("CSS")]
        CSS = 6,
        [Description("HTML")]
        HTML = 7,

    }
}
