using MediLabDapper.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UITestimonialViewComponent")]
    public class UITestimonialViewComponent(ITestimonialRepository repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await repository.GetAllAsync();
            return View(values);
        }
    }
}
