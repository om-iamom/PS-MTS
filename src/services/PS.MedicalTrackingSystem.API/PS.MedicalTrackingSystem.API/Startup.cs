using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PS.MedicalTrackingSystem.API.Business.Repositories;
using PS.MedicalTrackingSystem.API.Business.Services;
using PS.MedicalTrackingSystem.API.DataAccess.Repositories;
using PS.MedicalTrackingSystem.API.DataAccess.Services;
using PS.MedicalTrackingSystem.API.Settings.Repositories;
using PS.MedicalTrackingSystem.API.Settings.Services;

namespace PS.MedicalTrackingSystem.API
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
            services.AddControllers();
            
            // Configuaring database
            services.Configure<MedicineTrackingSystemDatabaseSettings>(Configuration.GetSection(nameof(MedicineTrackingSystemDatabaseSettings)));

            //Services configuration
            services.AddSingleton<IMedicineTrackingSystemDatabaseSettings>
                (sp => sp.GetRequiredService<IOptions<MedicineTrackingSystemDatabaseSettings>>().Value
                );
            services.AddScoped<IMedicineContext, MedicineContext>();
            services.AddScoped<IMedicineBusiness, MedicineBusiness>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medicine Tracking System API", Version = "v1" });
            }
          );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medicine Tracking System API");
            });
        }
    }
}
