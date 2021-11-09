using DataAccess.EFCore;
using API.Mapping;
using System.Reflection;

namespace API.Extensions.ServiceCollection
{
    public static class AutoMappingServiceCollectionExtension
    {
        public static IServiceCollection AddAutoMapperMapping(this IServiceCollection services)
        {
             services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(TtnContext).Assembly));
            });

            return services;
        }
    }
}