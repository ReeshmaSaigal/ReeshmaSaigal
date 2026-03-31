using Microsoft.EntityFrameworkCore;
using TourDestinationMVCApp.Models;
using TourDestinationMVCApp.Helper;
using TourDestinationMVCApp.Services;
using TourDestinationMVCApp.Interfaces;


namespace TourDestinationMVCApp.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DestinationDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddAutoMapper(typeof(AppProfile));
            services.AddHttpContextAccessor();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();


            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
