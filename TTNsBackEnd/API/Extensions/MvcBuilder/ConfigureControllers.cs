using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.MvcBuilder
{
    public static class ConfigureControllersIMVCBuilderExtension
    {
        public static IMvcBuilder ConfigureControllers(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddNewtonsoftJson(opt =>
               {
                   opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
               })
               .AddFluentValidation(opt =>
               {
                   opt.RegisterValidatorsFromAssemblyContaining<Startup>();
                   opt.LocalizationEnabled = false;
               });

            return mvcBuilder;
        }
    }
}