using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.Controllers
{
    public class AppointmentController(IAppointmentRepository _repository, IDepartmentRepository _departmentRepository, IDoctorRepository _doctorRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _repository.GetAppointmentsWDocWDep();
            var listAppointment = values.OrderByDescending(x => x.Date).Where(x => x.FullName != null).ToList();
            return View(listAppointment);
        }

        public async Task<JsonResult> GetDoctorsByDepartment(int departmentId)
        {
            var doctors = await _doctorRepository.GetAllDoctorsWithDepartmentIdAsync(departmentId);
            var doctorList = doctors.Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.DoctorId.ToString()
            }).ToList();

            return Json(doctorList);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departmentList = (from x in departments
                                      select new SelectListItem
                                      {
                                          Text = x.DepartmentName,
                                          Value = x.DepartmentId.ToString(),
                                      }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto dto)
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

            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departmentList = (from x in departments
                                      select new SelectListItem
                                      {
                                          Text = x.DepartmentName,
                                          Value = x.DepartmentId.ToString(),
                                      }).ToList();

            var doctorList = await _doctorRepository.GetAllDoctorsWithDepartmentIdAsync(value.DepartmentId);
            ViewBag.doctorList = doctorList
           .Select(x => new SelectListItem
           {
               Text = x.NameSurname,
               Value = x.DoctorId.ToString()
           }).ToList();

            var updateDto = new UpdateAppointmentDto
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
        public async Task<IActionResult> Update(UpdateAppointmentDto dto)
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
            var updateDto = new UpdateAppointmentDto
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
            var updateDto = new UpdateAppointmentDto
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
            var updateDto = new UpdateAppointmentDto
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
