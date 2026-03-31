using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.Admin.Interfaces
{
    public interface IBranchRepository
    {
        Task<Branch> AddBranchAsync(Branch branch);
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchByIdAsync(Guid id);

        Task<Branch> UpdateBranchAsync(Branch branch);
        Task<bool> DeleteBranchAsync(Guid id);
    }
}
