using AutoMapper;
using Domain.Modules.Products.DTO;
using Domain.Modules.Products.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Products.RequestObject;

namespace SmartStock.API.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var dto = _mapper.Map<CreateProductDto>(request);
            await _service.CreateAsync(dto);
            return Ok(new { message = "Product added successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            var dto = _mapper.Map<UpdateProductDto>(request);
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Product updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Product deleted successfully" });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
            => Ok(await _service.SearchAsync(keyword));

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            await _service.ToggleStatusAsync(id);
            return Ok(new { message = "Product status updated" });
        }
    }
}
