using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using RazorFields.Attributes;
using RazorFields.Extension;
using RazorFields.Helpers;
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

        
        // TODO add nested arrays instantiation
        private void InstantiateModels(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                var instance = InstanceHelper.InstantiateType(type);
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

        public IList<object> GetModels()
        {
            return this.RazorModels.Values.ToList();
        }
    }
}