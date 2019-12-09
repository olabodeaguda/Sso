using Business360.sso.Core.Interfaces.Services;
using Business360.sso.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AppServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpAccessorService, HttpAccessorService>();
        }
    }
}
