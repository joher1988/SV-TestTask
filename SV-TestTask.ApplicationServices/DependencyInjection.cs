using Microsoft.Extensions.DependencyInjection;

namespace SV_TestTask.ApplicationServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServicesDependencies(this IServiceCollection services)
        {
            return services.AddScoped<ISearchEngine, SearchEngine>();
        } 
    }
}