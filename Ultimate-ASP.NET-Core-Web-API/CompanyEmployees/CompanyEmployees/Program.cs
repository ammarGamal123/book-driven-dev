using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using LoggerService;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().
    LoadConfigurationFromFile(
    string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")
    );


// Add services to the container
builder.Services.AddControllers();

// custom configuration for service method inside builder
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegeration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else 
    app.UseHsts();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});



app.UseAuthorization();

app.MapControllers();

app.Run();
