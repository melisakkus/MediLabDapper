using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class UILayoutController(IAppointmentRepository repository) : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }

        public async Task<JsonResult> GetAvailableAppointments(int departmentId, int doctorId)
        {
            try
            {
                // Debug için log ekle
                Console.WriteLine($"GetAvailableAppointments çağrıldı - DepartmentId: {departmentId}, DoctorId: {doctorId}");

                if (departmentId <= 0 || doctorId <= 0)
                {
                    return Json(new { success = false, message = "Geçersiz departman veya doktor ID'si" });
                }

                var values = await repository.GetAvailableAppointmentsWDocWDep(departmentId, doctorId);
                var resultList = values?.ToList() ?? new List<ResultAppointmentDto>();

                Console.WriteLine($"Bulunan randevu sayısı: {resultList.Count}");

                // Eğer ResultAppointmentDto'da Date ve Time string formatında değilse, düzenle
                var formattedResults = resultList.Select(x => new
                {
                    appointmentId = x.AppointmentId,
                    date = x.Date.ToString("dd/MM/yyyy"),
                    time = x.Time.ToString(@"hh\:mm"), // Saat formatını düzenle
                    doctorName = x.NameSurname,
                    departmentName = x.DepartmentName
                }).ToList();

                return Json(formattedResults);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAvailableAppointments hatası: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UIAppointmentCreate(CreateAppointmentDto dto, string SelectedAppointment)
        {
            // For debugging
            System.Diagnostics.Debug.WriteLine($"Received DTO.Date: {dto.Date}, DTO.Time: {dto.Time}");
            System.Diagnostics.Debug.WriteLine($"Received SelectedAppointment: {SelectedAppointment}");

            if (!ModelState.IsValid)
            {
                // Log ModelState errors for detailed debugging
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                System.Diagnostics.Debug.WriteLine("ModelState Errors: " + string.Join(", ", errors));
                return BadRequest(ModelState); // This is the 400 error source
            }

            try
            {
                // The dto.Date and dto.Time are already correctly set from HiddenDate and HiddenTime
                // The SelectedAppointment string is used to get the appointmentId to update
                if (!string.IsNullOrEmpty(SelectedAppointment) && SelectedAppointment.Contains('|'))
                {
                    var parts = SelectedAppointment.Split('|');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int appointmentId))
                    {
                        // dto contains FullName, Email, Phone, Message, and also the correct Date and Time
                        // for the slot being booked.
                        await repository.UpdateAppointmentWithUserInfo(appointmentId, dto); // Pass the whole DTO
                                                                                            // Your UpdateAppointmentWithUserInfo should use dto.FullName, dto.Email etc.
                                                                                            // It seems it already does.
                        return Content("OK"); // Return JSON for php-email-form
                    }
                    else
                    {
                        ModelState.AddModelError("SelectedAppointment", "Seçilen randevu formatı geçersiz.");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    // This case means no pre-defined slot was chosen, which might be an error in your flow
                    // if users MUST pick from available slots.
                    ModelState.AddModelError("", "Lütfen listeden geçerli bir randevu saati seçiniz.");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in UIAppointmentCreate: {ex.ToString()}");
                // For php-email-form, it's better to return a JSON error
                return StatusCode(500, new { message = "Randevu kaydedilirken bir sunucu hatası oluştu: " + ex.Message });
            }
        }
    }
}