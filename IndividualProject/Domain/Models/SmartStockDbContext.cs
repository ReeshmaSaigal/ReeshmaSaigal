using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SmartStockDbContext : DbContext
    {
        public SmartStockDbContext(DbContextOptions<SmartStockDbContext> options)
            : base(options)
        {
        }

        //  Auth / User
        public DbSet<AppUser> Users => Set<AppUser>();
        public DbSet<PasswordReset> PasswordResets => Set<PasswordReset>();

        //  Product
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        // Supplier
        public DbSet<Supplier> Suppliers => Set<Supplier>();

        //  Stock
        public DbSet<StockTransaction> StockTransactions => Set<StockTransaction>();
        public DbSet<InventoryLog> InventoryLogs => Set<InventoryLog>();

        //  Purchase
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<PurchaseItem> PurchaseItems => Set<PurchaseItem>();

        //  Sales
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();


    }
}
