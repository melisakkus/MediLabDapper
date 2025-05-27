using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
