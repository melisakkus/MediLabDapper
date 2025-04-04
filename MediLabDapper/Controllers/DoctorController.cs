using MediLabDapper.Dtos.DoctorDtos;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.Controllers
{
    public class DoctorController(IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _doctorRepository.GetAllDoctorsWithDepartmentAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }

        private async Task GetDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.Departments = (from department in departments
                                   select new SelectListItem
                                   {
                                       Text = department.DepartmentName,
                                       Value = department.DepartmentId.ToString()
                                   }).ToList();
        }

        public async Task<IActionResult> CreateDoctor()
        {
            await GetDepartments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            await GetDepartments();
            await _doctorRepository.CreateDoctorAsync(createDoctorDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {
            await GetDepartments();
            var values = await _doctorRepository.GetDoctorByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await GetDepartments();
            await _doctorRepository.UpdateDoctorAsync(updateDoctorDto);
            return RedirectToAction("Index");
        }

    }
}
