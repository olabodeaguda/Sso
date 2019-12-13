using Business360.sso.Api.Data;
using Business360.sso.Api.Utilities;
using Business360.sso.Data;
using Business360.sso.Data.Entities;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Business360.sso.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkNpgsql()
                .AddDbContextPool<APPDbContext>((serviceProvider, optionsBuilder) =>
                {
                    optionsBuilder.UseNpgsql(connectionstring).EnableSensitiveDataLogging();
                    optionsBuilder.UseInternalServiceProvider(serviceProvider);
                });

            services.AddTransient<DbContext, APPDbContext>();
        }

        public static IHost DbMigration(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    scope.ServiceProvider.GetRequiredService<APPDbContext>().Database.Migrate();
                    scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                    scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();

                    InitializeUser(scope.ServiceProvider);
                    InitializeIdentityServer(scope.ServiceProvider);
                }
                catch (Exception ex)
                {
                    //Log.Error(ex);
                }
            }
            return host;
        }

        private static void InitializeIdentityServer(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ConfigurationDbContext>();
            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.GetIdentityResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.GetApis())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }

        private static void InitializeUser(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
            var chsakell = userManager.FindByNameAsync("business360admin").Result;
            if (chsakell == null)
            {
                chsakell = new ApplicationUser
                {
                    UserName = "business360admin"
                };
                var result = userManager.CreateAsync(chsakell, "@Password123").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                chsakell = userManager.FindByNameAsync("business360admin").Result;

                result = userManager.AddClaimsAsync(chsakell, new Claim[]{
                    new Claim(JwtClaimTypes.Name, "Business360 admin"),
                    new Claim(JwtClaimTypes.GivenName, "SSO"),
                    new Claim(JwtClaimTypes.FamilyName, "Business360"),
                    new Claim(JwtClaimTypes.Email, "olabodeaguda@outlook.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "https://olabodeaguda.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'localhost 10', 'postal_code': 11146, 'country': 'Greece' }",
                        IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }).Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Console.WriteLine("Business 360 created");
            }
            else
            {
                Console.WriteLine("Business 360 already exists");
            }
        }
    }
}
