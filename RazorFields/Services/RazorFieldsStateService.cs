using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RazorFields.Attributes;
using RazorFields.Extension;
using RazorFields.Helpers;
using RazorFields.Interfaces;

namespace RazorFields.Services
{
    public class RazorFieldsStateService : IRazorFieldsStateService
    {
        private readonly IServiceProvider _sp;
        public IDictionary<Type, object> RazorModels { get; set; } = new Dictionary<Type, object>();

        public RazorFieldsStateService(IServiceProvider sp)
        {
            _sp = sp;
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

        private void Save(object model)
        {
            using (var scope = this._sp.CreateScope())
            {
                foreach (var extension in scope.ServiceProvider.GetServices<IRazorFieldsExtension>())
                    extension.TrySaveModel(model);
            }
        }

        private bool TryPopulate(Type type, out object model)
        {
            model = null;
            using (var scope = this._sp.CreateScope())
            {
                foreach (var extension in scope.ServiceProvider.GetServices<IRazorFieldsExtension>())
                    if (extension.TryPopulateModel(type, out model))
                        return true;
            }

            return false;
        }

        // TODO add nested arrays instantiation
        private void InstantiateModels(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (!this.TryPopulate(type, out var instance))
                    instance = InstanceHelper.InstantiateType(type);

                if (instance is null) continue;
                // this.TryPopulate(instance);
                this.RazorModels.Add(type, instance);
                this.Save(instance);
            }
        }
    }
}