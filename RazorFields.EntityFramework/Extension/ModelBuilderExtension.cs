using Microsoft.EntityFrameworkCore;
using RazorFields.EntityFramework.Persistence;

namespace RazorFields.EntityFramework.Extension
{
    public static class ModelBuilderExtension
    {
        public static void UseRazorFields(this ModelBuilder builder)
        {
            builder.Entity<PersistenceRazorModel>();
        }
    }
}