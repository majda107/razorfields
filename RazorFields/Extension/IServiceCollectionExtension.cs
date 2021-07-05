using Microsoft.Extensions.DependencyInjection;
using RazorFields.Interfaces;
using RazorFields.Services;

namespace RazorFields.Extension
{
    public static class IServiceCollectionExtension
    {
        public static void AddRazorFields(this IServiceCollection services)
        {
            var service = new RazorFieldsService();
            services.AddSingleton<IRazorFieldsService, RazorFieldsService>((_) => service);
        }
    }
}