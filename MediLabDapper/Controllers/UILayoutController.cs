using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
