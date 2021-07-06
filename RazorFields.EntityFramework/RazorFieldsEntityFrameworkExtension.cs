using System.Linq;
using Microsoft.EntityFrameworkCore;
using RazorFields.EntityFramework.Persistence;
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
            var type = model.GetType();

            var set = this._db.Set<PersistenceRazorModel>();
            
            var entry = set.FirstOrDefault(entity => entity.Name == type.Name);
            if (entry == null) return false;
            
            // TODO implement population

            return true;
        }
    }
}