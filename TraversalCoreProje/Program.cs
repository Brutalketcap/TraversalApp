﻿using BusinessLayer.Continer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Serilog;
using TraversalCoreProje.CQRS.Handers.DestinationHanders;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            var path = Directory.GetCurrentDirectory();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File($"{path}\\LogFile\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddLogging(x =>
            {

                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });


            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();


            builder.Services.ContainerDependences();


            builder.Services.AddControllersWithViews(opt =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            ///void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
            ////{

            //    var path = Directory.GetCurrentDirectory();
            //    loggerFactory.AddFile($"{path}\\Logs\\log1.txt");
            //}

            //app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");
            ///


            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddTransient<IValidator<AnnouncementAddDTOs>, AnnouncementValidator>();  
            builder.Services.AddControllersWithViews()
                .AddFluentValidation();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();


            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            */

            var path = Directory.GetCurrentDirectory();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File($"{path}\\LogFile\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Log yapılandırması
            builder.Host.UseSerilog();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();



            builder.Services.AddScoped<GetAllDestinationQueryHanders>();     ///---
            builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
            builder.Services.AddScoped<CreateDestinationCommandHandler>();
            builder.Services.AddScoped<RemoveDestinationCommandHandler>();
            builder.Services.AddScoped<UpdateDestinationCommandHandler>();

            builder.Services.AddMediatR(typeof(Program).Assembly);


            builder.Services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });


            // DbContext ve Identity ayarları
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

            builder.Services.AddHttpClient();

            // Bağımlılıkları ekle
            builder.Services.ContainerDependences();

            // Kimlik doğrulama filtresi
            builder.Services.AddControllersWithViews(opt =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddMvc().AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SingIn";
            });


            // AutoMapper ve FluentValidation yapılandırması
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.CustomerValidator(); 

            // FluentValidation'ı MVC ile entegre et
            builder.Services.AddControllersWithViews()
                .AddFluentValidation();

            var app = builder.Build();

            // Hata yönetimi ve HSTS ayarları
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var supportedCultures = new[] { "tr","en","es","fr","gr","de" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);

            app.MapStaticAssets();

            // Route ayarları
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();

            // Endpoints yapılandırması
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });




        }
    }
}
