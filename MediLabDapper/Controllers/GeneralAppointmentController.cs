using MediLabDapper.Dtos.GeneralAppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.GeneralAppointmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.Controllers
{
    public class GeneralAppointmentController(IGeneralAppointmentRepository _repository, IDepartmentRepository _departmentRepository, IDoctorRepository _doctorRepository, IAppointmentRepository _appointmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _appointmentRepository.GetAppointmentsWDocWDep();
            var listAppointment = values.OrderByDescending(x => x.Date).Where(x => x.FullName == null).ToList();

            var notEmptyAppointmentList = await _appointmentRepository.GetAppointmentsWDocWDep();
            ViewBag.NotEmptyAppointments = notEmptyAppointmentList.OrderByDescending(x => x.Date).Where(x => x.FullName != null).ToList();
            return View(listAppointment);
        }

        public async Task<JsonResult> GetDoctorsByDepartmentId(int departmentId)
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
            var departmentList = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departmentList = (from x in departmentList
                                      select new SelectListItem
                                      {
                                          Text = x.DepartmentName,
                                          Value = x.DepartmentId.ToString()
                                      }).ToList();
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
            var departmentList = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departmentList = (from x in departmentList
                                      select new SelectListItem
                                      {
                                          Text = x.DepartmentName,
                                          Value = x.DepartmentId.ToString()
                                      }).ToList();

            var value = await _repository.GetByIdAsync(id);

            var doctorList = await _doctorRepository.GetAllDoctorsWithDepartmentIdAsync(value.DepartmentId);
            ViewBag.doctorList = doctorList
           .Select(x => new SelectListItem
           {
               Text = x.NameSurname,
               Value = x.DoctorId.ToString()
           }).ToList();

            var updateDto = new GeneralUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                Date = value.Date,
                Time = value.Time,
                DepartmentId = value.DepartmentId,
                DoctorId = value.DoctorId,
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

    }
}
