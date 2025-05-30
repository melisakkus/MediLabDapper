using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.GeneralAppointmentDtos
{
    public class GeneralUpdateAppointmentDto
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Randevu tarihi boş bırakılamaz.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Randevu saati boş bırakılamaz.")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "Bölüm seçilmelidir.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Doktor seçilmelidir.")]
        public int DoctorId { get; set; }

    }
}
