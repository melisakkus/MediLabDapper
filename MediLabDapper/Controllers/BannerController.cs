using MediLabDapper.Dtos.BannerDtos;
using MediLabDapper.Repositories.BannerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class BannerController(IBannerRepository _bannerRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _bannerRepository.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _bannerRepository.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _bannerRepository.GetByIdAsync(id);
            var updateDto = new UpdateBannerDto
            {
                BannerId = value.BannerId,
                Title = value.Title,
                Description = value.Description,
                Icon = value.Icon
            };  
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _bannerRepository.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bannerRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
