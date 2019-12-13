using Business360.sso.Core.Interfaces;
using Business360.sso.Core.Interfaces.Managers;
using Business360.sso.Core.Interfaces.Repositories;
using Business360.sso.Core.Interfaces.Services;
using Business360.sso.Core.Managers;
using Business360.sso.Data.Repositories;
using Business360.sso.Infrastructure.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;

namespace Business360.sso.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AppServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services
            services.AddScoped<IHttpAccessorService, HttpAccessorService>();
            //services.AddTransient<IClientStore, ClientStore>();
            //services.AddTransient<IResourceStore, ResourceStore>();

            //Repository
            //services.AddScoped<IClientRepository, ClientRepository>();
            //services.AddScoped<IIdentityResourceRepository, IdentityResourceRepository>();
            //services.AddScoped<IApiResourceRepository, ApiResourceRepository>();

            //Managers
            //services.AddScoped<IClientManager, ClientManager>();
            //services.AddScoped<IApiResourceManager, ApiResourceManager>();

        }

        public static void AddDocumentationConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Business360 SSO API"
                });

                //var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                //c.IncludeXmlComments(xmlFile);
                var securityScheme = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                };
                c.AddSecurityDefinition("Bearer", securityScheme);
                var r = new Dictionary<OpenApiSecurityScheme, IList<string>>
                  {
                    { securityScheme, new string[] { } }
                  };

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //     OpenApiSecurityRequirement
                //});
            });

        }
    }
}
