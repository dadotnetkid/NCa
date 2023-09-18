using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Casino.Applications.Shared
{
    public static class DependencyResolver
    {
        public static void Initialize(IHost app)
        {
            ServiceProvider = app.Services;
        }

        public static IServiceProvider ServiceProvider { get; set; }

        public static T GetRequiredService<T>() where T : notnull
        {
            return ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<T>();
        }

    }
}