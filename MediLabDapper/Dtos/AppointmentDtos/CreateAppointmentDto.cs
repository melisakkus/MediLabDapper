using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {

        [Required(ErrorMessage = "Ad soyad boş bırakılamaz.")]
        [MaxLength(150, ErrorMessage = "Ad soyad en fazla 150 karakter olabilir.")]
        public string FullName { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [MaxLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
        [Phone(ErrorMessage = "Geçersiz telefon numarası formatı.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Randevu tarihi boş bırakılamaz.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Randevu saati boş bırakılamaz.")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "Bölüm seçilmelidir.")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Doktor seçilmelidir.")]
        public int? DoctorId { get; set; }

        [MaxLength(400, ErrorMessage = "Randevu saati en fazla 400 karakter olabilir.")]
        public string? Message { get; set; }

        public AppointmentStatusDto IsApproved { get; set; }

    }
}
