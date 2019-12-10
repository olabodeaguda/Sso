using Business360.sso.Data;
using Business360.sso.Data.Entities;
using Business360.sso.Data.Repositories;
using Business360.sso.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Business360.sso.Api.Extensions
{
    public static class SecurityExtensions
    {
        public static void SSoConfiguration(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment _environment)
        {
            var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "b360.pfx"), "@Olabode.123");

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<APPDbContext>();

            services.AddIdentityServer()
              .AddSigningCredential(cert)
              .AddResourceStore<ResourceStore>()
              .AddClientStore<ClientStore>()
              .AddAspNetIdentity<ApplicationUser>()
              .AddProfileService<IdentityWithAdditionalClaimsProfileService>();
        }
    }
}
