using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Admin
{
    public class BranchRepository : IBranchRepository
    {
        private readonly StudentManagementDbContext _context;

        public BranchRepository(StudentManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Branch> AddBranchAsync(Branch branch)
        {
            try
            {
				await _context.Branches.AddAsync(branch);
				await _context.SaveChangesAsync();
				return branch;
			}
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
           return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetBranchByIdAsync(Guid id)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
        }

        public async Task<Branch> UpdateBranchAsync(Branch branch)
        {
            _context.Branches.Update(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<bool> DeleteBranchAsync(Guid id)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(x => x.BranchId == id);

            if (branch == null)
                return false;

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
