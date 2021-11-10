using API.Extensions.MvcBuilder;
using API.Extensions.ServiceCollection;
using API.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory());

builder.Services.AddAutoMapperMapping();
builder.Services.AddUnitOfWork(builder.Configuration);
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ExceptionFilter));
}).ConfigureControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();