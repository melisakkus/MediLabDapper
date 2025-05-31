using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.DepartmentDtos
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Bölüm adı boş bırakılamaz.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Bölüm adı 3 ile 100 karakter arasında olmalıdır.")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }

    }
}
