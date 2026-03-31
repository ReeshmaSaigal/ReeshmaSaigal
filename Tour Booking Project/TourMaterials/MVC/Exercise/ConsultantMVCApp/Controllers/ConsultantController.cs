using ConsultantMVCApp.DTO;
using ConsultantMVCApp.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConsultantMVCApp.Controllers
{
    public class ConsultantController : Controller
    {
        private readonly IConsultantService _service;

        public ConsultantController(IConsultantService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var consultants = await _service.GetAllAsync();
            return View(consultants);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateConsultantDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, error) = await _service.CreateAsync(dto);

            if (!success)
            {
                ModelState.AddModelError("", error);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var consultant = await _service.GetByIdAsync(id);
            if (consultant == null)
                return NotFound();

            return View(consultant);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var consultant = await _service.GetByIdAsync(id);
            if (consultant == null)
                return NotFound();

            return View(consultant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ConsultantDetailsDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _service.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var consultant = await _service.GetByIdAsync(id);
            if (consultant == null)
                return NotFound();

            return View(consultant);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


