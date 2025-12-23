using Enterprise.Application;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Infrastructure.Identity;
using Enterprise.Infrastructure.Identity.Contexts;
using Enterprise.Infrastructure.Identity.Models;
using Enterprise.Infrastructure.Identity.Seeds;
using Enterprise.Infrastructure.Persistence;
using Enterprise.Infrastructure.Persistence.Contexts.Configurations;
using Enterprise.Infrastructure.Persistence.Seeds;
using Enterprise.Infrastructure.Resources;
using Enterprise.WebApi.Infrastructure.Extensions;
using Enterprise.WebApi.Infrastructure.Middlewares;
using Enterprise.WebApi.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddIdentityInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddResourcesInfrastructure();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddMediator();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomSwagger();
builder.Services.AddAnyCors();
builder.Services.AddAuthorization();
builder.Services.AddCustomLocalization(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    if (!useInMemoryDatabase)
    {
        await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
        await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
    }

    //Seed Data
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
    await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
}

app.UseCustomLocalization();
app.UseAnyCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomSwagger();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");
app.MapEndpoints();
app.UseSerilogRequestLogging();

app.Run();

public partial class Program
{
}
