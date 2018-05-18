namespace Foxkit.Helpers.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        #if NET40 || NET45 || NET46 || NETSTANDARD2_0
        public static T ToEnum<T>(this string input, T defaultValue)
            where T : IConvertible
        {
            if (defaultValue is Enum)
            {
                var type = defaultValue.GetType();
                var values = (T[])Enum.GetValues(type);

                foreach (var val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (descriptionAttributes.Length > 0)
                    {
                        var description = ((DescriptionAttribute)descriptionAttributes[0]).Description;

                        if (description.ToLower().RemoveMultipleSpaces() == input.ToLower().RemoveMultipleSpaces())
                        {
                            return val;
                        }
                    }
                }
            }

            return defaultValue;
        }
        #else 
        public static T ToEnum<T>(this string input, T defaultValue)
        {
            if (!(defaultValue is Enum))
            {
                return defaultValue;
            }

            var type = defaultValue.GetType();
            var values = (T[])Enum.GetValues(type);

            foreach (var val in values)
            {
                var attribute = val.GetType().GetTypeInfo().GetCustomAttribute<DescriptionAttribute>(false);

                if (!attribute.IsNullOrDefault() && attribute.Description.ToLower().RemoveMultipleSpaces() == input.ToLower().RemoveMultipleSpaces())
                {
                    return val;
                }
            }

            return defaultValue;
        }
        #endif
    }
}
