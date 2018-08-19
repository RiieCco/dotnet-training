using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORS.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CORS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>options.UseSqlite("Data Source=identity.db"));

            // ===== Add our DbContext ========
            services.AddDbContext<IdentityContext>();

            // ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Dotnet security training course",
                    Description = "This part of the course covers authorization attacks such as CORS & CSRF. Here we are going to learn how to exploit and mitigate the attack",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Riccardo ten Cate/Glenn ten Cate",
                        Email = string.Empty,
                        Url = string.Empty
                    },
                    License = new License
                    {
                        Name = "Copyright 2018; Riccardo ten Cate",
                        Url = "https://example.com/license"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyOrigin().
                AllowAnyMethod().
                AllowCredentials()
             );

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IdentityContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
