using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.GeneralAppointmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.ViewComponents
{
    [ViewComponent(Name = "UIAppointmentViewComponent")]
    public class UIAppointmentViewComponent(IDepartmentRepository _departmentRepository,IAppointmentRepository _appointmentRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departmentList = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.Departments = (from x in departmentList
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                      Value = x.DepartmentId.ToString()
                                  }).ToList();
            return View();
        }
    }
}
