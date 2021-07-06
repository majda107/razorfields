using Microsoft.EntityFrameworkCore;
using RazorFields.Interfaces;

namespace RazorFields.EntityFramework
{
    public class RazorFieldsEntityFrameworkExtension<T> : IRazorFieldsExtension where T : DbContext
    {
        private readonly T _db;

        public RazorFieldsEntityFrameworkExtension(T db)
        {
            _db = db;
        }

        public bool TryPopulateModel(object model)
        {
            throw new System.NotImplementedException();
        }
    }
}