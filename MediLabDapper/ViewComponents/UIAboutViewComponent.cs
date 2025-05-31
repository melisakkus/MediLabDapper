using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIAboutViewComponent")]
    public class UIAboutViewComponent(IAboutRepository aboutRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await aboutRepository.GetAllAsync();
            return View(values);
        }
    }
}
