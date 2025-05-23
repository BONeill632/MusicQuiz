using System.ComponentModel;
using System.Reflection;

namespace MusicQuiz.Core.Enums
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the description of an enum value
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            if (enumValue == null)
            {
                return string.Empty;
            }

            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null)
            {
                return enumValue.ToString();
            }

            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute != null ? descriptionAttribute.Description : enumValue.ToString();
        }
    }
}
