namespace Foxkit
{
    using System;
    using System.Reflection;

    public static class GenericExtension
    {
        public static bool IsNullOrDefault<T>(this T argument)
        {
            if (Equals(argument, default(T)))
            {
                return true;
            }

            var methodType = typeof(T);
            var underlyingType = Nullable.GetUnderlyingType(methodType);

            if (underlyingType != null && Equals(argument, Activator.CreateInstance(underlyingType)))
            {
                return true;
            }

            var argumentType = argument.GetType();

            #if NET40
            if (argumentType.IsValueType && argumentType != methodType)
            {
                var obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }
            #else
            if (argumentType.GetTypeInfo().IsValueType && argumentType != methodType)
            {
                var obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }
            #endif

            return false;
        }

        public static void ArgumentNotNull<T>(this T argument, string argumentName)
        {
            if (argument.IsNullOrDefault())
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
