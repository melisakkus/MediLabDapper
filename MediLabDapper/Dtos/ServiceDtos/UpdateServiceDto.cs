using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage ="Ikon bilgisi boş bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Ikon bilgisi en fazla 50 karakter olabilir.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(400, ErrorMessage = "Açıklama en fazla 400 karakter olabilir.")]
        public string Explanation { get; set; }
    }
}
