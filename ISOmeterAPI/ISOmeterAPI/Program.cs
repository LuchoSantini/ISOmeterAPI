using ISOmeterAPI.Context;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISOmeterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Dependency Injections
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();
            #endregion

            builder.Services.AddDbContext<ISOmeterContext>(dbContextOptions =>
                dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString"])
            );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
