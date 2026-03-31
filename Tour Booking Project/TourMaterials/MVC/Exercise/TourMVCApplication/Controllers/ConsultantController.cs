using Microsoft.AspNetCore.Mvc;

namespace ConsultantMVCApplication.Controllers
{
    public class ConsultantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
