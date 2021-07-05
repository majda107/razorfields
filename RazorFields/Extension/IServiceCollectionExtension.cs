using Microsoft.Extensions.DependencyInjection;
using RazorFields.Interfaces;
using RazorFields.Services;

namespace RazorFields.Extension
{
    public static class IServiceCollectionExtension
    {
        public static void AddRazorFields(this IServiceCollection services)
        {
            services.AddSingleton<IRazorFieldsService, RazorFieldsService>((s) => new RazorFieldsService());
        }
    }
}