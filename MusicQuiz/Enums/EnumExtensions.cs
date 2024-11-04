using System.ComponentModel;
using System.Reflection;

namespace MusicQuiz.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            if (enumValue is null)
            {
                return string.Empty;
            }
            else
            {
                var descriptionAttribute = enumValue.GetType()
    .GetField(enumValue.ToString())
    .GetCustomAttribute<DescriptionAttribute>();

                return descriptionAttribute != null ? descriptionAttribute.Description : enumValue.ToString();
            }

        }
    }
}
