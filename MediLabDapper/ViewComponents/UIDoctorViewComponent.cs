using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIDoctorViewComponent")]
    public class UIDoctorViewComponent(IDoctorRepository _doctorRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _doctorRepository.GetAllDoctorsWithDepartmentAsync();
            return View(values);
        }
    }
}
