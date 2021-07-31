using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using RazorFields.Attributes;
using RazorFields.Extension;
using RazorFields.Helpers;
using RazorFields.Interfaces;

namespace RazorFields.Services
{
    public class RazorFieldsService : IRazorFieldsService
    {
        private readonly IRazorFieldsStateService _state;

        public RazorFieldsService(IRazorFieldsStateService state)
        {
            _state = state;
        }


        public T GetModel<T>()
        {
            var type = typeof(T);
            if (this._state.RazorModels.TryGetValue(type, out var instance))
                return (T) instance;

            return default;
        }

        public IList<(Type, object)> GetModels()
        {
            return this._state.RazorModels.Keys
                .Select(k => (k, this._state.RazorModels[k]))
                .ToList();
        }

        public Type FindType(string name) => this._state.RazorModels.Keys.FirstOrDefault(t => t.Name == name);

        public bool UpdateModel(object value)
        {
            var type = value?.GetType();

            // if type not found
            if (type == null || !this._state.RazorModels.ContainsKey(type)) return false;

            this._state.RazorModels[type] = value;
            this._state.Save(value);

            return true;
        }

        public void ResetModel(Type type)
        {
            if (!this._state.RazorModels.ContainsKey(type)) return;

            var instance = InstanceHelper.InstantiateType(type);
            this._state.RazorModels[type] = instance;
            this._state.Save(instance);
        }
    }
}