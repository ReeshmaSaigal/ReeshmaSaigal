using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Admin.RequestObjects;
using StudentManagement.Controllers;

namespace StudentManagement.API.Admin
{

    [ApiController]
    [Authorize]
    public class BranchController :BaseAPIController <BranchController>
    {
        private readonly IBranchService _branchservice;

        public BranchController(IBranchService branchservice)
        {
            _branchservice = branchservice;
        }

        [HttpPost("addbranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchDto dto)
        {
            var result = await _branchservice.AddBrachAsync(dto);
            return Ok(
                new
                {
                    Message = "Branch added successfully",
                    Data = result
                });

        }

        [HttpGet("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches()
        {
            return Ok(await _branchservice.GetAllBranchAsync());

        }

        [HttpGet("GetBranchById/{id}")]
        public async Task<IActionResult> GetBranchById(Guid id)
        {
            var result = await _branchservice.GetBranchByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { Message = "Branch not found" });
            }
            return Ok(result);
        }


        [HttpPut("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(Guid id, [FromBody] BranchDto dto)
        {
            var updated = await _branchservice.UpdateBranchAsync(id, dto);

            if (updated == null)
                return NotFound(new { Message = "Branch not found" });

            return Ok(new
            {
                Message = "Branch updated successfully",
                Data = updated
            });
        }

        [HttpDelete("DeleteBranch/{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            var deleted = await _branchservice.DeleteBranchAsync(id);

            if (!deleted)
                return NotFound(new { Message = "Branch not found" });

            return Ok(new { Message = "Branch deleted successfully" });
        }


    }
}
