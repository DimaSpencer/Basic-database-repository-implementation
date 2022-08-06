using DSp.BasicRepositoryImplementation.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DSp.BasicRepositoryImplementation.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBasicRepositoryImplementationServices(this IServiceCollection services)
        {
            services.AddTransient<IDynamicFilterService, DynamicFilterService>();
            services.AddTransient<IDynamicSortingService, DynamicSortingService>();
            services.AddTransient<IPaginationService, PaginationService>();

            return services;
        }

        //public static IServiceCollection AddRepository<TRepository, TImplementation, TEntity, TKey>(this IServiceCollection services,
        //    TRepository repository, TImplementation implementation)
        //        where TImplementation : class, IDbRepository<TEntity, TKey>
        //{
        //    services.AddScoped();
        //}
    }
}
