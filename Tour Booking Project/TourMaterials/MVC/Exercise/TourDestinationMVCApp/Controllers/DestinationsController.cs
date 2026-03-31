using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TourDestinationMVCApp.DTO;
using TourDestinationMVCApp.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TourDestinationMVCApp.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService _service;
        private readonly IMapper _mapper;

        public DestinationsController(IDestinationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        private (string userId, string role) GetSession()
        {
            return (
                HttpContext.Session.GetString("UserId"),
                HttpContext.Session.GetString("Role")
            );
        }
        // ==============================
        // INDEX (AGENCY, CUSTOMER, CONSULTANT)
        // ==============================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CUSTOMER" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            var list = await _service.GetAllAsync();
            return View(list);
        }

        // ==============================
        // CREATE (AGENCY, CONSULTANT)
        // ==============================
        public IActionResult Create()
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            return View(new DestinationDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationDto dto)
        {
            var (userId, role) = GetSession();
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            if (!ModelState.IsValid) return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // ==============================
        // EDIT (AGENCY, CONSULTANT)
        // ==============================
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Account");

            if (role != "AGENCY" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var dto = _mapper.Map<DestinationDto>(existing);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DestinationDto dto)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            if (!ModelState.IsValid) return View(dto);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // ==============================
        // DETAILS (AGENCY, CUSTOMER, CONSULTANT)
        // ==============================
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CUSTOMER" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // ==============================
        // DELETE (AGENCY, CONSULTANT)
        // ==============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Account");

            if (role != "AGENCY" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}