using ISOmeterAPI.Context;
using ISOmeterAPI.Services.Implementations;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ISOmeterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region JWT
            var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
            var jwtAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });
            #endregion

            #region DBService
            builder.Services.AddSingleton<IExportDBService>(provider =>
            {
                string connectionString = builder.Configuration["DB:ConnectionString"];
                return new ExportDBService(connectionString);
            });
            #endregion

            #region DBContext
            builder.Services.AddDbContext<ISOmeterContext>(dbContextOptions =>
                dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString"])
            );

            #endregion

            #region Dependency Injections
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEssayService, EssayService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            #endregion

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("ISOmeter-API-BearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Ingresar el token para autenticarse."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ISOmeter-API-BearerAuth"
                            }
                        },
                        new List<string>()
                    }
                });
            });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
