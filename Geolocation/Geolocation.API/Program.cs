using Geolocation.Api.AddressToGeolocationApi;
using Geolocation.Api.DbContexts;
using Geolocation.Api.Profiles;
using Geolocation.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
    options.SuppressAsyncSuffixInActionNames = false;
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddDbContext<GeolocationContext>(
    dbContextOpts => dbContextOpts.UseSqlite(
        builder.Configuration["ConnectionStrings:GeolocationDBConnectionString"]), 
    ServiceLifetime.Singleton);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGeolocationRepository, GeolocationRepository>();
builder.Services.AddScoped<IGeolocationDataCollector, GeolocationDataCollector>();
builder.Services.AddAutoMapper(typeof(GeolocationProfile));
builder.Services.AddAutoMapper(typeof(GeolocationDetailsProfile));
builder.Services.AddAutoMapper(typeof(LocationProfile));
builder.Services.AddAutoMapper(typeof(LanguageProfile));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geolocation API");
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
