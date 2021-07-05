using System;
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

        private void InstantiateModels(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                if (instance is null) continue;

                this.RazorModels.Add(type, instance);
            }
        }
    }
}