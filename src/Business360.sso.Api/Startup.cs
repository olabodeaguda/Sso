using Business360.sso.Api.Extensions;
using Business360.sso.Api.Filters;
using Business360.sso.Api.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            services.AppServicesConfiguration(Configuration);
            services.AddDatabaseConfiguration(Configuration);
            services.AddDocumentationConfiguration();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.Converters.Add(new TrimmingConverter());
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business360 SSO API");
                c.RoutePrefix = "";
            });
        }
    }
}
