using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PTS2.Web.Utilities
{
    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length > 0 ? ((DescriptionAttribute)attr[0]).Description : enumValue.ToString();
        }
        public static T ParseEnum<T>(this string stringVal)
        {
            return (T)Enum.Parse(typeof(T), stringVal);
        }
        public static string GetValue(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DefaultValueAttribute), false);
            return attr.Length > 0 ? ((DescriptionAttribute)attr[0]).Description : enumValue.ToString();
        }


        public static string GetDescriptionFromGeneric<T>(this T enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length > 0 ? ((DescriptionAttribute)attr[0]).Description : enumValue.ToString();
        }

    }
}