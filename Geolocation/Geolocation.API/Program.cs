using Geolocation.Api.DbContexts;
using Geolocation.Api.Profiles;
using Geolocation.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
    options.SuppressAsyncSuffixInActionNames = false;
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GeolocationContext>(
    dbContextOpts => dbContextOpts.UseSqlite(
        builder.Configuration["ConnectionStrings:GeolocationDBConnectionString"]));
builder.Services.AddScoped<IGeolocationRepository, GeolocationRepository>();
builder.Services.AddAutoMapper(typeof(GeolocationProfile));
builder.Services.AddAutoMapper(typeof(GeolocationDetailsProfile));
builder.Services.AddAutoMapper(typeof(LocationProfile));
builder.Services.AddAutoMapper(typeof(LanguagesProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
