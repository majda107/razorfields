using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RazorFields.Extension
{
    public static class TypeExtension
    {
        public static bool IsRecord(this Type type)
        {
            return type.GetMethods().Any(m => m.Name == "<Clone>$");
        }

        public static bool IsGenericEnumerableType(this Type type)
        {
            return (type.GetInterface(nameof(IEnumerable)) != null) && type.IsGenericType;
        }
    }
}