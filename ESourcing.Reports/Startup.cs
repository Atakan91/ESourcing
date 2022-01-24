using ESourcing.Reports.Data;
using ESourcing.Reports.Data.Interfaces;
using ESourcing.Reports.Repositories;
using ESourcing.Reports.Repositories.Interfaces;
using ESourcing.Reports.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Reports
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

            services.Configure<ReportDatabaseSettings>(Configuration.GetSection(nameof(ReportDatabaseSettings)));
            services.AddSingleton<IReportDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ReportDatabaseSettings>>().Value);

            #endregion

            #region Project Dependencies

            services.AddTransient<IReportContext, ReportContext>();
            services.AddTransient<IReportRepository, ReportRepository>();

            #endregion

            #region Swagger Dependencies

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ESourcing.Reports",
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESourcing.Reports v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
