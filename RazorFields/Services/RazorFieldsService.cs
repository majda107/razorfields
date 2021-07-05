using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using RazorFields.Attributes;
using RazorFields.Extension;
using RazorFields.Interfaces;

namespace RazorFields.Services
{
    public class RazorFieldsService : IRazorFieldsService
    {
        public IDictionary<Type, object> RazorModels { get; set; }

        public RazorFieldsService()
        {
            this.RazorModels = new Dictionary<Type, object>();

            this.Init();
        }

        private void Init()
        {
            // var asm = Assembly.GetExecutingAssembly();
            var asm = Assembly.GetEntryAssembly();

            var models = asm?
                .GetTypes().ToList()
                .Where(t =>
                    t.IsRecord() &&
                    t.GetCustomAttribute<RazorModelAttribute>() is not null
                ) ?? ImmutableArray<Type>.Empty;

            this.InstantiateModels(models);
        }

        private object InstantiateType(Type type)
        {
            object instance;
            
            // check for default types
            if (type == typeof(string))
                instance = "";
            else
                instance = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties().Where(p => p.PropertyType.IsGenericEnumerableType()))
            {
                var elementType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                if (elementType == null) continue;

                var propInstance = this.InstantiateType(elementType);
                
                Type genericListType = typeof(List<>);
                Type concreteListType = genericListType.MakeGenericType(elementType);
                
                var list = Activator.CreateInstance(concreteListType) as IList;
                list?.Add(propInstance);

                prop.SetValue(instance, list);
            }

            return instance;
        }

        // TODO add nested arrays instantiation
        private void InstantiateModels(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                var instance = this.InstantiateType(type);
                if (instance is null) continue;

                this.RazorModels.Add(type, instance);
            }
        }

        public T GetModel<T>()
        {
            var type = typeof(T);
            if (this.RazorModels.TryGetValue(type, out var instance))
                return (T) instance;

            return default;
        }
    }
}