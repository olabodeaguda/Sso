using Business360.sso.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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


            services.AddEntityFrameworkNpgsql()
                .AddDbContextPool<ApplicationDbContext>((serviceProvider, optionsBuilder) =>
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
                    var context = scope.ServiceProvider.GetRequiredService<APPDbContext>();
                    context.Database.Migrate();

                    var context1 = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context1.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //Log.Error(ex);
                }
            }
            return host;
        }
    }
}
