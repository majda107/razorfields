using System.Collections.Generic;

namespace RazorFields.Interfaces
{
    public interface IRazorFieldsService
    {
        public T GetModel<T>();
        public IList<object> GetModels();
    }
}