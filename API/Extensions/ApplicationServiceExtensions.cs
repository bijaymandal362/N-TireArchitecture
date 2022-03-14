using BusinessLayer.Common;
using Data;
using Hangfire;
using Hangfire.Storage.SQLite;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<AuditDataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("AuditDefaultConnection"));
            });

            services.AddHangfire(opt=>
            {
                opt.UseSQLiteStorage(config.GetConnectionString("HangfireConnection"));
            });

           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddCors(opt =>
             {
                opt.AddPolicy("CorsPolicy", policy =>
                 {
                     policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                 });
            });

            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPersonAccessor, PersonAccessor>();
            return services;
        }
    }
}