using Microsoft.EntityFrameworkCore;
using ConsultantMVCApp.Models;
using ConsultantMVCApp.Helper;
using ConsultantMVCApp.Service;
using ConsultantMVCApp.Interfaces;
using ConsultantMVCApp.Repository;
using ConsultantMVCApp.Interface;
using ConsultantMVCApp.Services;


namespace ConsultantMVCApp.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddAutoMapper(typeof(AppProfile));

            services.AddScoped<IConsultantRepository, ConsultantRepository>();
            services.AddScoped<IConsultantService, ConsultantService>();


            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
