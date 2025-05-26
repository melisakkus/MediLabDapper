using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
