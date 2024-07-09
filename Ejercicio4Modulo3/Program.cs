using Ejercicio4Modulo3.Api.Middlewares;
using Ejercicio4Modulo3.Aplication.Services;
using Ejercicio4Modulo3.Data;
using Ejercicio4Modulo3.Domain.Contracts;
using Ejercicio4Modulo3.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddScoped<LogRepository>();
            builder.Services.AddScoped<ProveedorRepository>();
            
            builder.Services.AddTransient<LoggingMiddleware>();
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();

            var app = builder.Build();
            
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseMiddleware<LoggingMiddleware>();
            });
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}