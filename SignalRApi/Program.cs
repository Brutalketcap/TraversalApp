using SignalRApi.Model;
using Microsoft.OpenApi.Models;
using SignalRApi.DAL;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Hubs; // Ekledik

namespace SignalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SignalR API",
                    Version = "v1"
                });
            });
            //builder.Services.AddDbContext<Context>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddScoped<VisitorService>();
            //builder.Services.AddSignalR();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //               .AllowAnyMethod()
            //               .AllowAnyHeader()
            //               .SetIsOriginAllowed((host)=> true) 
            //               .AllowCredentials();
            //    });
            //});
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalR API v1");
                });
            }

            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.MapControllers();
            
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<VisitorHub>("/visitorHub");
            //});


            app.Run();

        }
    }
}