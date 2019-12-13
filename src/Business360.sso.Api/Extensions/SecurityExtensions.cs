using Business360.sso.Api.Data;
using Business360.sso.Api.Utilities;
using Business360.sso.Data;
using Business360.sso.Data.Entities;
using Business360.sso.Data.Repositories;
using Business360.sso.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Business360.sso.Api.Extensions
{
    public static class SecurityExtensions
    {
        public static void SSoConfiguration(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment _environment)
        {
            var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "b360.pfx"), configuration.GetValue<string>("CertPassword"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<APPDbContext>()
                .AddDefaultTokenProviders();

            #region MyRegion
            //services.AddIdentityServer()
            //  .AddSigningCredential(cert)
            //  .AddResourceStore<ResourceStore>()
            //  .AddClientStore<ClientStore>()
            //  .AddAspNetIdentity<ApplicationUser>()
            //  .AddProfileService<IdentityWithAdditionalClaimsProfileService>();

            //        services.AddIdentityServer()
            //.AddInMemoryClients(Config.GetClient())
            //.AddInMemoryIdentityResources(Config.GetIdentityResources())
            //.AddInMemoryApiResources(Config.GetApiResources())
            //.AddTestUsers(Config.Get())
            //.AddDeveloperSigningCredential(); 
            #endregion

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                  // this adds the config data from DB (clients, resources)
                  .AddConfigurationStore(options =>
                  {
                      options.ConfigureDbContext = opt =>
                      {

                          opt.UseNpgsql(connectionString,
                              optionsBuilder =>
                                  optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
                      };
                  })
                  // this adds the operational data from DB (codes, tokens, consents)
                  .AddOperationalStore(options =>
                  {
                      options.ConfigureDbContext = opt =>
                      {
                          opt.UseNpgsql(connectionString,
                              optionsBuilder =>
                                  optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
                      };

                      // this enables automatic token cleanup. this is optional.
                      options.EnableTokenCleanup = true;
                  })
                  .AddAspNetIdentity<ApplicationUser>()
                  .AddSigningCredential(cert);


            services.AddAuthentication();
        }
    }
}
