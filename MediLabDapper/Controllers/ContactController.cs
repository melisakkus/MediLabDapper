using MediLabDapper.Dtos.ContactDtos;
using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.Controllers
{
    public class ContactController(IContactRepository _repository) : Controller
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
        public async Task<IActionResult> Create(CreateContactDto dto)
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
            var updateDto = new UpdateContactDto
            {
                ContactId = value.ContactId,
                Location = value.Location,
                Phone = value.Phone,
                Email = value.Email
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto dto)
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
