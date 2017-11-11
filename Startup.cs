using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace convertizzle
{
    public class Startup
    {
        /// <summary>
        /// Gets the global application configuration
        /// </summary>
        /// <returns></returns>
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
   
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CCContext");

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<CCContext>(options => options.UseNpgsql(connectionString));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("apiKey", new ApiKeyScheme {
                   Name = "apiKey",
                   In = "Header" 
                });
                //c.IncludeXmlComments(GetXmlDocFile());
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1", Description = "Main documentation" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "convertizzle API Documentation");
            });
        }

        
        /// <summary>
        /// Gets the created documentation xml file
        /// </summary>
        /// <returns></returns>
        public string GetXmlDocFile()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(baseDirectory);
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            return Path.Combine(baseDirectory, commentsFileName);
            
        }
    }
}
