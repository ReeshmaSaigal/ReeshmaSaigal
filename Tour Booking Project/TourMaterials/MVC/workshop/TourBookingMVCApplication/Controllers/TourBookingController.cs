using Microsoft.AspNetCore.Mvc;
using TourBookingMVCApplication.DTO;
using TourBookingMVCApplication.Interfaces;

namespace TourBookingMVCApplication.Controllers
{
    public class TourBookingController : Controller
    {
        private readonly ITourBookingService _service;

        public TourBookingController(ITourBookingService service)
        {
            _service = service;
        }

        // ==============================
        // SESSION HELPER
        // ==============================
        private (string userId, string role) GetSession()
        {
            return (
                HttpContext.Session.GetString("UserId"),
                HttpContext.Session.GetString("Role")
            );
        }

        // ==============================
        // GET ALL (AGENCY, CONSULTANT)
        // ==============================
        public async Task<IActionResult> Index()
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CONSULTANT" && role!="CUSTOMER")
                return RedirectToAction("AccessDenied");

            var result = await _service.GetAllToursAsync();
            return View(result);
        }

        // ==============================
        // CREATE (AGENCY, CUSTOMER, CONSULTANT)
        // ==============================
        public IActionResult Create(Guid Id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Auth");

            if (role != "AGENCY" && role != "CUSTOMER" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingDto dto, Guid Id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            if (role != "AGENCY" && role != "CUSTOMER" && role != "CONSULTANT")
                return RedirectToAction("AccessDenied");

            Guid parsedUserId = Guid.Parse(userId);

            var alreadyBooked = await _service.IsAlreadyBooked(parsedUserId, Id);

            if (alreadyBooked)
            {
                TempData["Error"] = "User has already booked this tour.";
                return RedirectToAction("Details", "Tours", new { id = Id });
            }

            dto.UserId = parsedUserId;

            var booking = await _service.CreateAsync(dto, Id);

            return RedirectToAction("Details", new { id = booking.Id });
        }

        // ==============================
        // DETAILS (AGENCY, CUSTOMER, CONSULTANT)
        // ==============================
        public async Task<IActionResult> Details(Guid id)
        {
            var (userId, role) = GetSession();

            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login");

            // ✅ Always get booking by booking ID
            var booking = await _service.GetByIdAsync(id);

            if (booking == null)
                return NotFound();

            // ✅ Get tour using booking.TourId
            var tour = await _service.GetByIdTourAsync(booking.TourId);

            var viewModel = new TourDetailsDto
            {
                Tour = tour,
                Booking = booking
            };

            return View(viewModel);
        }
       

       

        
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}