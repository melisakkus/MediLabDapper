using MediLabDapper.Dtos.TestimonialDtos;
using MediLabDapper.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        { 
            var values = await _testimonialRepository.GetAllAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _testimonialRepository.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _testimonialRepository.GetByIdAsync(id);
            var updateDto = new UpdateTestimonialDto
            {
                TestimonialId = value.TestimonialId,
                FullName = value.FullName,
                Comment = value.Comment,
                Review = value.Review,
                JobTitle = value.JobTitle,
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _testimonialRepository.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
