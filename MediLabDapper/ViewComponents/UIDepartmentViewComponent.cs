using MediLabDapper.Repositories.DepartmanRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIDepartmentViewComponent")]
    public class UIDepartmentViewComponent(IDepartmentRepository _departmentRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }
    }
}
