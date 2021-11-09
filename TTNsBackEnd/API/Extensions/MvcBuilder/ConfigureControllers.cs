using FluentValidation.AspNetCore;

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
                   opt.RegisterValidatorsFromAssemblyContaining<Program>();
                   opt.LocalizationEnabled = false;
               });

            return mvcBuilder;
        }
    }
}