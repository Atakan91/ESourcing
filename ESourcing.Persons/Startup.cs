using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using ESourcing.Persons.Data;
using ESourcing.Persons.Data.Interfaces;
using ESourcing.Persons.Repositories;
using ESourcing.Persons.Repositories.Interfaces;
using ESourcing.Persons.Settings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ESourcing.Persons
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

            #region Configuration Dependency

            services.Configure<PersonDatabaseSettings>(Configuration.GetSection(nameof(PersonDatabaseSettings)));
            services.AddSingleton<IPersonDatabaseSettings>(sp => sp.GetRequiredService<IOptions<PersonDatabaseSettings>>().Value);
            #endregion

            #region Project Dependencies

            services.AddTransient<IPersonContext, PersonContext>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            #endregion

            #region Swagger Dependencies

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ESourcing.Persons",
                    Version = "v1"
                });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESourcing.Persons v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
