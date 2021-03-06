﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using ng_core_api.Services;
using ng_core_api.Entities;
using ng_core_api.Dtos;


namespace ng_core_api
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
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			
			// Configure CORS so the API allows requests from JavaScript.  
            // For demo purposes, all origins/headers/methods are allowed.  
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddScoped<ITourManagementRepository, TourManagementRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.Band, Dtos.Band>();
                config.CreateMap<Entities.Manager, Dtos.Manager>();
                config.CreateMap<Entities.Tour, Dtos.Tour>()
                    .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name))
                    .ForMember(d => d.Manager, o => o.MapFrom(s => s.Manager.Name));
                config.CreateMap<Entities.Show, Dtos.Show>();
            });

            //app.UseHttpsRedirection();
			// Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");
            app.UseMvc();
        }
    }
}
