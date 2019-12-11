using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business360.sso.Api.Extensions;
using Business360.sso.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business360.sso.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("*"));
            });
            services.SSoConfiguration(Configuration, _environment);
            services.AddDatabaseConfiguration(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = error.Error;

                        //var logger = context.RequestServices.GetService<ILoggerService>();
                        //logger.Error(exception);

                        var (responseModel, statusCode) = GlobalExceptionFilter.GetStatusCode<object>(exception);
                        context.Response.StatusCode = (int)statusCode;
                        context.Response.ContentType = "application/json";

                        var responseJson = JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                        await context.Response.WriteAsync(responseJson);
                    });
            });

        }
    }
}
