using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.Controllers
{
    public class AboutController(IAboutRepository _repository) : Controller
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
        public async Task<IActionResult> Create(CreateAboutDto dto)
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
            var updateDto = new UpdateAboutDto
            {
                AboutId = value.AboutId,
                Description = value.Description,
                Title1 = value.Title1,
                Explanation1 = value.Explanation1,
                Title2 = value.Title2,
                Explanation2 = value.Explanation2,
                Title3 = value.Title3,
                Explanation3 = value.Explanation3
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
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
