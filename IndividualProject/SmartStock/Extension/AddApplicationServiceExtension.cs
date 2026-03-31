using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartStock.Helper;
using Domain.Helper;

using Domain.Modules.Auth.Interface;
using Domain.Modules.Auth;
using Domain.Modules.User;
using Domain.Modules.Suppliers;
using Domain.Modules.Suppliers.Interface;
using Domain.Modules.Products;
using Domain.Modules.Products.Interface;
using Domain.Modules.Categories;
using Domain.Modules.Categories.Interface;
using Domain.Modules.User.Interface;
using Domain.Modules.Stocks.Interace;
using Domain.Modules.Stocks;
using Domain.Modules.Purchases.Interface;
using Domain.Modules.Purchases;
using Domain.Modules.Sales.Interface;
using Domain.Modules.Sales;
namespace SmartStock.Extension
{
    public static class AddApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService
            (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SmartStockDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MappingProfile));

            // 🔹 Auth module
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService,AuthService>();

            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            services.AddScoped<IJwtHelper, JwtHelper>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
             

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<IStockTransactionRepository, StockTransactionRepository>();
            services.AddScoped<IStockTransactionService, StockTransactionService>();

            services.AddScoped<IPurchaseRepository,PurchaseRepository>();   
            services.AddScoped<IPurchaseService,PurchaseService>();

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();    

            return services;
        }
    }
}
