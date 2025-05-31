using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }

        [Required(ErrorMessage = "Ad soyad boş bırakılamaz.")]
        [MaxLength(150, ErrorMessage = "Ad soyad en fazla 150 karakter olabilir.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Yorum boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "Yorum en fazla 250 karakter olabilir.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Değerlendirme boş bırakılamaz.")]
        public int Review { get; set; }
        public string? JobTitle { get; set; }
        public string? ImageUrl { get; set; }

    }
}
