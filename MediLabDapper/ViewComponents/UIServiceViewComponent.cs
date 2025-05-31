using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIServiceViewComponent")]
    public class UIServiceViewComponent(IServiceRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _repository.GetAllAsync();
            return View(values);
        }
    }    
}
