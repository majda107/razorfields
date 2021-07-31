using Microsoft.EntityFrameworkCore;
using RazorFields.EntityFramework.Extension;

namespace RazorFields.Demo.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=data.db");
            
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseRazorFields();
            
            base.OnModelCreating(builder);
        }
    }
}