using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
