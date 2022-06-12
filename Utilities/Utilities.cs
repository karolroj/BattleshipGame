using System.ComponentModel;
using System.Reflection;

namespace WarshipGame.Utilities
{
    public static class Utilities
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            FieldInfo? fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo != null)
                {
                DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
            }
            return "No description for enum.";
        }
    }
}
