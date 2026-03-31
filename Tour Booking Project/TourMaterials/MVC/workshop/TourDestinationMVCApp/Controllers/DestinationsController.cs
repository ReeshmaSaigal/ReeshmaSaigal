using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using TourDestinationMVCApp.DTO;
using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;
using TourDestinationMVCApp.Controllers;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new DestinationDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var created = await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            var dto = _mapper.Map<DestinationDto>(existing);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DestinationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
