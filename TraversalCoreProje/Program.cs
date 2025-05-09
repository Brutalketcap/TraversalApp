using BusinessLayer.Continer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
using TraversalCoreProje.CQRS.Handers.DestinationHanders;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
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


            builder.Services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });


            // DbContext ve Identity ayarları
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddEntityFrameworkStores<Context>();

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
