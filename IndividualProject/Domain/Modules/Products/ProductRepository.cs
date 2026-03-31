using Domain.Models;
using Domain.Modules.Products.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Products
{
    public class ProductRepository:IProductRepository
    {
        private readonly SmartStockDbContext _context;

        public ProductRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
            => await _context.Products.Include(p => p.Category)
                                      .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Product product)
            => await _context.Products.AddAsync(product);

        public async Task UpdateAsync(Product product)
            => _context.Products.Update(product);

        public async Task DeleteAsync(Product product)
            => _context.Products.Remove(product);

        public async Task<List<Product>> SearchAsync(string keyword)
            => await _context.Products
                .Where(p => p.Name.Contains(keyword))
                .ToListAsync();

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
