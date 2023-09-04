using JWTAuth.WebApi.Extensions;
using JWTAuth.WebApi.Models;
using JWTAuth.WebApi.Modules.Jwt.Endpoints;

namespace JWTAuth.WebApi.Modules.Jwt
{
    public class JwtModule :IModule
    {
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            services.AddTransient<JwtEndpoints>();
            return services;
        }
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            var rootConfigurations = endpoints.MapGroup("").WithTags("Jwt");
            rootConfigurations.MapPost("token/", async (UserInfo model,JwtEndpoints scanEndpoint) =>
                await scanEndpoint.Post(model));

           

            return endpoints;
        }
    }
}
