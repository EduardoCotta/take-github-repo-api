using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TakeGithubAPI.Models.Repository;
using TakeGithubAPI.Models.Service;
using TakeGithubAPI.Repository;
using TakeGithubAPI.Service;
using TakeGithubAPI.Utils;

namespace TakeGithubAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IGithubRepoService, GithubRepoService>();
            services.AddScoped<IGithubRepoRepository, GithubRepoRepository>();
            services.AddScoped<IApplicationEnviroment, ApplicationEnviroment>();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Github Repository Manager API",
                        Version = "v1",
                        Description = "Essa é uma API de demonstração construída com .NET Core utilizando C#. Seu objetivo principal é retornar os repositórios mais antigos da Take.net que utilizam C#.",
                        Contact = new OpenApiContact
                        {
                            Name = "Eduardo Cotta",
                            Url = new Uri("https://github.com/EduardoCotta")
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Github Repository Manager API V1");
            });

            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
