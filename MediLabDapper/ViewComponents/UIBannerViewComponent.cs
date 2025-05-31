using MediLabDapper.Repositories.BannerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIBannerViewComponent")]
    public class UIBannerViewComponent(IBannerRepository bannerRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await bannerRepository.GetAllAsync();
            return View(values);
        }
    }
}
