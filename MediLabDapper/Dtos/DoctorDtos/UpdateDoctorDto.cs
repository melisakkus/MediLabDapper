using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Ad ve soyad boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "Ad soyad en az 5 karakter olmalıdır.")]
        public string NameSurname { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bölüm bilgisi boş bırakılamaz.")]
        public int? DepartmentId { get; set; }
    }

}
