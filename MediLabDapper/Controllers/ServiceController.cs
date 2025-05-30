using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class ServiceController(IServiceRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _repository.GetAllAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _repository.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            var updateDto = new UpdateServiceDto
            {
                ServiceId = value.ServiceId,
                Title = value.Title,
                Explanation = value.Explanation,
                Icon = value.Icon
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _repository.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
