using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIFooterViewComponent")]
    public class UIFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
