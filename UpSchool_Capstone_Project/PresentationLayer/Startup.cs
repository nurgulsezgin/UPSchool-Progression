// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PresentationLayer.Models;
//using BusinessLayer.DIContainer;


using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLayer.DIContainer;
using FluentValidation.AspNetCore;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Authorization;
//using FluentValidation.AspNetCore;


namespace PresentationLayer
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
            //Extensions DIContainers
            services.ContainerDependencies();

            //FluentValidation
            services.AddControllersWithViews().AddFluentValidation();

            //DbContext
            services.AddDbContext<RecipeContext>();
            //Identity
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
                .AddEntityFrameworkStores<RecipeContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<RecipeIdentityValidator>();//Identity Error Validation
            //Identity Confirm Password
            services.Configure<IdentityOptions>(opts =>
            {
                opts.SignIn.RequireConfirmedEmail = true;
            });

            // Type of startup for automapper
            //services.AddAutoMapper(typeof(Startup));
            //services.CustomizeValidator();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
