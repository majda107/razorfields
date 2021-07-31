using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorFields.Interfaces;

namespace RazorFields.EntityFramework.Extension
{
    public static class IServiceCollectionModel
    {
        public static void AddRazorFieldsEntityFramework<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddScoped<IRazorFieldsExtension, RazorFieldsEntityFrameworkExtension<T>>();
        }
    }
}