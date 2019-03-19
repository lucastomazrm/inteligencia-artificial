using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.ResponseCompression;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Console.Write(Configuration.GetSection("SECRET_KEY"));
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Inteligencia Artificial", Version = "v1" });
            });
            services.AddMvcCore()
                    .AddApiExplorer();

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var list = Configuration.GetSection("Application").GetChildren()
                    .Select(item => new KeyValuePair<string, string>(item.Key, item.Value))
                    .ToDictionary(x => x.Key, x => x.Value); ;

            foreach (var item in list)
            {
                Environment.SetEnvironmentVariable(item.Key, item.Value);
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseResponseCompression();
            app.UseCors("CorsPolicy");
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "apidocs";
                c.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
            });
            
            app.Run(async (context) =>
           {
               context.Response.ContentType = "text/html";

               if (string.IsNullOrWhiteSpace(env.WebRootPath))
               {
                   env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
               }
               await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
           });
        }
    }
}
