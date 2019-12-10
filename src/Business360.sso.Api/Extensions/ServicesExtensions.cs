using Business360.sso.Core.Interfaces.Services;
using Business360.sso.Data.Repositories;
using Business360.sso.Infrastructure.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business360.sso.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AppServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services
            services.AddScoped<IHttpAccessorService, HttpAccessorService>();
            services.AddTransient<IdentityServer4.Stores.IClientStore, ClientStore>();
            services.AddTransient<IdentityServer4.Stores.IResourceStore, ResourceStore>();


        }
    }
}
