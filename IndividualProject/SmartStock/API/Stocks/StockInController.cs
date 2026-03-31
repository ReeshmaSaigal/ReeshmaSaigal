using AutoMapper;
using Domain.Modules.Stocks.DTO;
using Domain.Modules.Stocks.Interace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Stocks.RequestObjects;

namespace SmartStock.API.Stocks
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInController : ControllerBase
    {
        private readonly IStockTransactionService _service;
        private readonly IMapper _mapper;

        public StockInController(IStockTransactionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockRequest request)
        {
            var dto = _mapper.Map<CreateStockDto>(request);
            var result = await _service.StockInAsync(dto);

            return StatusCode(201, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            var result = await _service.GetStockInHistoryAsync();
            return Ok(result);
        }

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
    }
}
