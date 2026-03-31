using AutoMapper;
using Domain.Modules.Purchases.DTO;
using Domain.Modules.Purchases.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.API.Purchases.RequestObject;

namespace SmartStock.API.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // POST /purchases
        [HttpPost]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseRequest request)
        {
            var dto = _mapper.Map<PurchaseDto>(request);
            var result = await _service.CreatePurchaseAsync(dto);

            return StatusCode(201, new
            {
                status = "SUCCESS",
                category = "PURCHASE_CREATED",
                data = result
            });
        }

        // GET /purchases
        [HttpGet]
        public async Task<IActionResult> GetPurchases()
        {
            var result = await _service.GetPurchasesAsync();
            return Ok(new
            {
                status = "SUCCESS",
                category = "PURCHASE_LIST",
                data = result
            });
        }

        // GET /purchases/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase(Guid id)
        {
            var result = await _service.GetPurchaseByIdAsync(id);
            if (result == null)
                return NotFound(new { status = "FAILED", category = "NOT_FOUND" });

            return Ok(new
            {
                status = "SUCCESS",
                category = "PURCHASE_DETAILS",
                data = result
            });
        }

        // PATCH /purchases/{id}/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            Guid id,
            UpdatePurchaseStatusRequest request)
        {
            var updated = await _service.UpdatePurchaseStatusAsync(id, request.Status);

            if (!updated)
                return NotFound(new { status = "FAILED", category = "NOT_FOUND" });

            return Ok(new
            {
                status = "SUCCESS",
                category = "PURCHASE_STATUS_UPDATED"
            });
        }
    }

}
