using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interfaces;

namespace Domain.Services.Admin
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<Branch> AddBrachAsync(BranchDto branchdto)
        {
            var branches = new Branch
            {
                BranchId = Guid.NewGuid(),
                BranchName = branchdto.BranchName,
                Location = branchdto.Location,
                PinCode = branchdto.PinCode,

				BranchCode=branchdto.Branchcode
			};
            return await _branchRepository.AddBranchAsync(branches);
        }

        public async Task<IEnumerable<Branch>> GetAllBranchAsync()
        {
            return await _branchRepository.GetAllBranchesAsync();
        }

        public async Task<Branch> GetBranchByIdAsync(Guid id)
        {
            return await _branchRepository.GetBranchByIdAsync(id);
        }

        public async Task<Branch> UpdateBranchAsync(Guid id, BranchDto dto)
        {
            var existingBranch = await _branchRepository.GetBranchByIdAsync(id);

            if (existingBranch == null)
                return null;

            existingBranch.BranchName = dto.BranchName;
            existingBranch.Location = dto.Location;
            existingBranch.PinCode = dto.PinCode;

            return await _branchRepository.UpdateBranchAsync(existingBranch);
        }

        public async Task<bool> DeleteBranchAsync(Guid id)
        {
            return await _branchRepository.DeleteBranchAsync(id);
        }

    }
}
