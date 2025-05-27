using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
