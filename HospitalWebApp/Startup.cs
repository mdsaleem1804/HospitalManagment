using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HospitalWebApp.Models;
using HospitalWebApp.Repositories;

using Microsoft.EntityFrameworkCore;
using HospitalWebApp.Interfaces;
using HospitalWebApp.Entities;
using AutoMapper;
using HospitalWebApp.Mappings;

namespace HospitalWebApp
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

            services.AddDbContext<ApplicationContext>(opts =>
                 opts.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddScoped(typeof(IPatient<Patient, int>), typeof(PatientRepository));
            services.AddScoped(typeof(IDoctor<Doctor, int>), typeof(DoctorRepository));
            services.AddScoped(typeof(IOutPatient<OutPatient, int>), typeof(OutPatientRepository));
            services.AddMvc();
            // Start Registering and Initializing AutoMapper

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddAutoMapper(typeof(Startup));

            // End Registering and Initializing AutoMapper

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
