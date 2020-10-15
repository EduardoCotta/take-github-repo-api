using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace TakeGithubAPI.Enums.Util
{
    public static class EnumParser
    {
        #region Public Methods

        /// <summary>
        /// Tries parsing a value into an enum based on the Regular Expression defined by the enum values' descriptions.
        /// </summary>
        public static T ParseOrDefault<T>(string value) where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            var result = values.Cast<T>().FirstOrDefault((v) => Regex.Match(value, v.GetDescription()).Success);
            return result;
        }

        #endregion Public Methods
    }
}