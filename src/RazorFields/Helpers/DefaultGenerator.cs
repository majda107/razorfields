using System;
using System.Reflection;

namespace RazorFields.Helpers
{
    public class DefaultGenerator
    {
        public static object GetDefaultValue(Type parameter)
        {
            var defaultGeneratorType =
                typeof(DefaultGenerator<>).MakeGenericType(parameter);

            return defaultGeneratorType.InvokeMember(
                "GetDefault", 
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.InvokeMethod,
                null, null, new object[0]);
        }
    }

    public class DefaultGenerator<T>
    {
        public static T GetDefault()
        {
            return default(T);
        }
    }
}