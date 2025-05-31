using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIContactViewComponent")]
    public class UIContactViewComponent(IContactRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _repository.GetAllAsync();
            return View(values);
        }
    }
}
