using System;
using System.Collections.Generic;

namespace RazorFields.Interfaces
{
    public interface IRazorFieldsService
    {
        public T GetModel<T>();
        
        public IList<(Type type, object value)> GetModels();
        public void UpdateModel(string name, object value);
    }
}