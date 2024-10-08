using ISOmeterAPI.Context;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ISOmeterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IExportDBService>(provider =>
            {
                // Obtiene la cadena de conexión desde la configuración
                string connectionString = builder.Configuration["DB:ConnectionString"];
                // Crea una instancia de ExportDBService pasando la cadena de conexión
                return new ExportDBService(connectionString);
            });

            #region Dependency Injections
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion

            builder.Services.AddDbContext<ISOmeterContext>(dbContextOptions =>
                dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString"])
            );

            builder.Services.AddControllers();
            //builder.Services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configuración de CORS
            app.UseCors(corsBuilder =>
            {
                corsBuilder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
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
