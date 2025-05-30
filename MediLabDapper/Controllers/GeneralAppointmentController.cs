using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class GeneralAppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
