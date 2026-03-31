using AutoMapper;
using Domain.Modules.Suppliers;
using Domain.Modules.Suppliers.DTO;
using Domain.Modules.Suppliers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Suppliers.RequestObject;

namespace SmartStock.API.Suppliers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: /suppliers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: /suppliers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: /suppliers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request)
        {
            var dto = _mapper.Map<CreateSupplierDto>(request);
            var result = await _service.CreateAsync(dto);

            return StatusCode(201, result);
        }

        // PUT: /suppliers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSupplierRequest request)
        {
            try
            {
                var dto = _mapper.Map<UpdateSupplierDto>(request);
                var result = await _service.UpdateAsync(id, dto);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: /suppliers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
