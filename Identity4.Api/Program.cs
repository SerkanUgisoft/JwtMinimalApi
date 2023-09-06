using Identity4.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
const string connectionString = @"Server=localhost;Database=JWTAuthentication;User Id=sa;Password=123;TrustServerCertificate=True";

builder.Services.AddIdentityServer()

    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddTestUsers(IdentityConfiguration.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseIdentityServer();
app.Run();

