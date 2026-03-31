using AutoMapper;
using Domain.Modules.Sales.DTO;
using Domain.Modules.Sales.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Sales.RequestObject;

namespace SmartStock.API.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _service;
        private readonly IMapper _mapper;

        public SalesController(ISaleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // POST /sales
        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleRequest request)
        {
            var dto = _mapper.Map<SaleDto>(request);
            var result = await _service.CreateSaleAsync(dto);

            return StatusCode(201, new
            {
                status = "SUCCESS",
                category = "SALE_CREATED",
                data = result
            });
        }

        // GET /sales
        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var result = await _service.GetSalesAsync();
            return Ok(new
            {
                status = "SUCCESS",
                category = "SALES_LIST",
                data = result
            });
        }

        // GET /sales/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(Guid id)
        {
            var result = await _service.GetSaleByIdAsync(id);

            if (result == null)
                return NotFound(new { status = "FAILED", category = "NOT_FOUND" });

            return Ok(new
            {
                status = "SUCCESS",
                category = "SALE_DETAILS",
                data = result
            });
        }

        // GET /sales/customer/{name}
        [HttpGet("customer/{name}")]
        public async Task<IActionResult> GetSalesByCustomer(string name)
        {
            var result = await _service.GetSalesByCustomerAsync(name);

            return Ok(new
            {
                status = "SUCCESS",
                category = "CUSTOMER_WISE_SALES",
                data = result
            });
        }
    }
}

