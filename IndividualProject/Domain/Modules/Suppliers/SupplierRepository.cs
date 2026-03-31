using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Modules.Suppliers.Interface;

namespace Domain.Modules.Suppliers
{
    public class SupplierRepository: ISupplierRepository
{
    private readonly SmartStockDbContext _context;

        public SupplierRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllAsync()
            => await _context.Suppliers.ToListAsync();

        public async Task<Supplier?> GetByIdAsync(Guid id)
            => await _context.Suppliers.FindAsync(id);

        public async Task AddAsync(Supplier supplier)
            => await _context.Suppliers.AddAsync(supplier);

        public void Update(Supplier supplier)
            => _context.Suppliers.Update(supplier);

        public void Delete(Supplier supplier)
            => _context.Suppliers.Remove(supplier);

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}

