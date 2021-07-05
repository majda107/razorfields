using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RazorFields.Extension;

namespace RazorFields.Helpers
{
    public static class InstanceHelper
    {
        public static object InstantiateType(Type type)
        {
            object instance = null;

            // check for default types

            if (type == typeof(string))
                instance = "";
            else if (type.IsPrimitive)
                instance = DefaultGenerator.GetDefaultValue(type);
            else
                instance = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties().Where(p => p.PropertyType.IsGenericEnumerableType()))
            {
                var elementType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                if (elementType == null) continue;

                var propInstance = InstantiateType(elementType);
                if(propInstance == null) continue;

                Type genericListType = typeof(List<>);
                Type concreteListType = genericListType.MakeGenericType(elementType);

                var list = Activator.CreateInstance(concreteListType) as IList;
                list?.Add(propInstance);

                prop.SetValue(instance, list);
            }

            return instance;
        }
    }
}