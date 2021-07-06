using System;
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

        public bool TryPopulateModel(Type type, out object model)
        {
            // var type = model.GetType();
            model = null;

            var set = this._db.Set<PersistenceRazorModel>();

            var entry = set
                .AsNoTracking()
                .FirstOrDefault(entity => entity.Name == type.Name);

            if (entry == null) return false;

            model = JsonConvert.DeserializeObject(entry.Content, type);

            return true;
        }

        public bool TrySaveModel(object model)
        {
            var type = model.GetType();

            var set = this._db.Set<PersistenceRazorModel>();
            var content = JsonConvert.SerializeObject(model);

            var entry = set
                .AsNoTracking()
                .FirstOrDefault(entity => entity.Name == type.Name);

            if (entry == null)
                entry = new PersistenceRazorModel
                {
                    Name = type.Name
                };

            entry.Content = content;

            this._db.Update(entry);
            this._db.SaveChanges();

            return true;
        }
    }
}