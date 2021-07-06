using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            var entry = set
                .AsNoTracking()
                .FirstOrDefault(entity => entity.Name == type.Name);
            
            if (entry == null) return false;

            JsonConvert.PopulateObject(entry.Content, model);

            return true;
        }

        public bool TrySaveModel(object model)
        {
            var type = model.GetType();
            
            var set = this._db.Set<PersistenceRazorModel>();
            
            var entry = set
                .AsNoTracking()
                .FirstOrDefault(entity => entity.Name == type.Name);

            if (entry == null)
                entry = new PersistenceRazorModel
                {
                    Name = type.Name
                };

            entry.Content = JsonConvert.SerializeObject(model);

            return true;
        }
    }
}