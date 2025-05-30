using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.Controllers
{
    public class AppointmentController(IAppointmentRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _repository.GetAllAsync();
            var listAppointment = values.OrderByDescending(x => x.Date).ToList();
            return View(listAppointment);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeneralCreateAppointmentDto dto)
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
            var updateDto = new GeneralUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                FullName = value.FullName,
                Email = value.Email,
                Phone = value.Phone,
                Date = value.Date,
                Time = value.Time,
                DepartmentId = value.DepartmentId,
                DoctorId = value.DoctorId,
                Message = value.Message,
                IsApproved = value.IsApproved
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GeneralUpdateAppointmentDto dto)
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


        public async Task<IActionResult> Approved(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            var updateDto = new GeneralUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                FullName = value.FullName,
                Email = value.Email,
                Phone = value.Phone,
                Date = value.Date,
                Time = value.Time,
                DepartmentId = value.DepartmentId,
                DoctorId = value.DoctorId,
                Message = value.Message,
                IsApproved = AppointmentStatusDto.Onaylı
            };
            await _repository.UpdateAsync(updateDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Decline(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            var updateDto = new GeneralUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                FullName = value.FullName,
                Email = value.Email,
                Phone = value.Phone,
                Date = value.Date,
                Time = value.Time,
                DepartmentId = value.DepartmentId,
                DoctorId = value.DoctorId,
                Message = value.Message,
                IsApproved = AppointmentStatusDto.Reddedildi
            };
            await _repository.UpdateAsync(updateDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Waiting(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            var updateDto = new GeneralUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                FullName = value.FullName,
                Email = value.Email,
                Phone = value.Phone,
                Date = value.Date,
                Time = value.Time,
                DepartmentId = value.DepartmentId,
                DoctorId = value.DoctorId,
                Message = value.Message,
                IsApproved = AppointmentStatusDto.Beklemede
            };
            await _repository.UpdateAsync(updateDto);
            return RedirectToAction("Index");
        }
    }
}
