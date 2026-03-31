using AutoMapper;
using Domain.Modules.User.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.User.RequestObject;
using SmartStock.Helper;
using Domain.Modules.User.DTO;
using Domain.Modules.User;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace SmartStock.API.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { 
    private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
            _mapper = mapper;
    }
        //[Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            var response = _mapper.Map< IEnumerable < UserResponse >>(users);

            return Ok(response);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        { 
            var user=await _service.GetByIdAsync(id);

            return Ok(_mapper.Map<UserResponse>(user));
        }

    //[HttpPost("CreateUser")]
    //public async Task<IActionResult> Create(CreateUserRequest request)
    //{
    //        var requestDto = _mapper.Map<CreateUserDto>(request);

    //    await _service.CreateAsync(requestDto);
    //    return Ok(new { message = "User created successfully",request });
    //}

    [HttpPut("UpDateUser/{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequest request)
    {
            var requestDto = _mapper.Map<UpdateUserDto>(request);
           var updatedUser= _mapper.Map < UserResponse > (await _service.UpdateAsync(id, requestDto));
        return Ok(new { message = "User updated successfully" ,updatedUser});
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
       var deletedUser=_mapper.Map<UserResponse>(await _service.DeleteAsync(id));
        return Ok(new { message = "User deleted successfully",deletedUser });
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> ToggleStatus(Guid id)
    {
        var status=await _service.ToggleStatusAsync(id);
        return Ok(new { message = "User status updated",status });
    }
}
}
