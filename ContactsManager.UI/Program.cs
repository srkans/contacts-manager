using ContactsManager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using Services;
using RepositoryContracts;
using Repositories;
using Serilog;
using CRUDExample.Filters.ActionFilters;
using CRUDExample;
using CRUDExample.Middleware;
using ContactsManager.UI;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

//Logging Serilog
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
                       .ReadFrom.Services(services);  
}); //serilog'un konfigurasyon ayarlarini ve servisleri okumayabilmesi icin

builder.Services.ConfigureServices(builder.Configuration); //my extension

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();
}

app.UseHsts(); //browser'� https'i aktif etmesi i�in bilgilendiriyor.
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();


if (builder.Environment.IsEnvironment("Test") != true)
{ 
Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
}

app.UseStaticFiles();

app.UseRouting(); //Identifying action method based route
app.UseAuthentication(); // reading identity cookie

app.UseAuthorization(); //validates access permissions of the user

app.MapControllers(); //Execute the filter pipeline (action + filters)

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}"
        );
    //Admin/Home/Index
});

app.UseHttpLogging();

app.Run();

public partial class Program { }
