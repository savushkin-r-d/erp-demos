using Microsoft.Extensions.Configuration;
using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.ServiceCollection
{
    public static class UnitOfWorkServiceCollectionExtension
    {
        ///<summary>
        /// Adds db context with default "DBConnection" connection string and inits UnitOfWork pattern
        /// with Generic repositories.
        ///</summary>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TtnContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"),
                    b => b.MigrationsAssembly(typeof(TtnContext).Assembly.FullName));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}