using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
