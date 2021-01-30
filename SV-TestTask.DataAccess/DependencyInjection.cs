using Microsoft.Extensions.DependencyInjection;
using SV_TestTask.DataAccess.DataSource;

namespace SV_TestTask.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDataSource, DataSource.DataSource>();
            return services;
        } 
    }
}