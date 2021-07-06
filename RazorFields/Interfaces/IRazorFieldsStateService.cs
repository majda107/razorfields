using System;
using System.Collections.Generic;

namespace RazorFields.Interfaces
{
    public interface IRazorFieldsStateService
    {
        IDictionary<Type, object> RazorModels { get; }

        void Save(object instance);
    }
}