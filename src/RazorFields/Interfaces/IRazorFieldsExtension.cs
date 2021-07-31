using System;

namespace RazorFields.Interfaces
{
    public interface IRazorFieldsExtension
    {
        public bool TryPopulateModel(Type type, out object model);
        public bool TrySaveModel(object model);
    }
}