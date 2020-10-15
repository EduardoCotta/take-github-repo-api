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
    }
}
