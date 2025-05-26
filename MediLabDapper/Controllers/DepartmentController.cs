using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Repositories.DepartmanRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }

        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createDepartmentDto);
            }
            await _departmentRepository.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            var value = new UpdateDepartmentDto
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDepartmentDto);
            }
            await _departmentRepository.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}
