using System;
using System.Linq;
using System.ComponentModel;

namespace TakeGithubAPI.Enums.Util
{
    public static class EnumExtensions
    {
        #region Public Methods

        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            var memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if (memberInfo?.Any() == true)
            {
                var attributes = memberInfo[default].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes?.Any() == true)
                {
                    return ((DescriptionAttribute)attributes.ElementAt(default)).Description;
                }
            }
            return genericEnum.ToString();
        }

        #endregion Public Methods
    }
}
