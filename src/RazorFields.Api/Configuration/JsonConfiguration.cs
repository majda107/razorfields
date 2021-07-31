using Newtonsoft.Json;

namespace RazorFields.Api.Configuration
{
    public static class JsonConfiguration
    {
        public static JsonSerializerSettings CreateReplaceSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;

            return settings;
        }
    }
}