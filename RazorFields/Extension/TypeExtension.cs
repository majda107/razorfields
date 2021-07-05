using System;
using System.Linq;

namespace RazorFields.Extension
{
    public static class TypeExtension
    {
        public static bool IsRecord(this Type type)
        {
            return type.GetMethods().Any(m => m.Name == "<Clone>$");
        }
    }
}