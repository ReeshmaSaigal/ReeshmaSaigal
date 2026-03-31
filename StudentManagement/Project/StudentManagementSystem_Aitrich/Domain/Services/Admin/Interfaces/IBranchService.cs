using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services.Admin.DTOs;

namespace Domain.Services.Admin.Interfaces
{
    public interface IBranchService
    {
        Task<Branch> AddBrachAsync(BranchDto branchdto);
        Task<IEnumerable<Branch>> GetAllBranchAsync();
        Task<Branch> GetBranchByIdAsync(Guid id);
        Task<Branch> UpdateBranchAsync(Guid id, BranchDto dto);
        Task<bool> DeleteBranchAsync(Guid id);
    }
}
