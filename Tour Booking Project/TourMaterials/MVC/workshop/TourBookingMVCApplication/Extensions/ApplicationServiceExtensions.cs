using Microsoft.EntityFrameworkCore;
using TourBookingMVCApplication.Models;
using TourBookingMVCApplication.Helper;
using TourBookingMVCApplication.Services;
using TourBookingMVCApplication.Interfaces;
using TourBookingMVCApplication.Repository;


namespace TourBookingMVCApplication.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddAutoMapper(typeof(AppProfile));
                     
            services.AddScoped<ITourBookingService, TourBookingService>();
            services.AddScoped<ITourBookingRepository, TourBookingRepository>();


            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
