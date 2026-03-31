using AutoMapper;
using Domain.Modules.Categories.DTO;
using Domain.Modules.Categories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Category.RequestObject;

namespace SmartStock.API.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET /categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result); // 200
        }

        // POST /categories
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var dto = _mapper.Map<CreateCategoryDto>(request);
            var category = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetAll), category); // 201
        }

        // PUT /categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryRequest request)
        {
            var dto = _mapper.Map<UpdateCategoryDto>(request);
            var category = await _service.UpdateAsync(id, dto);

            return Ok(category); // 200
        }

        // DELETE /categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok(new { message = "Category deleted successfully" }); // 200
        }
    }

}

