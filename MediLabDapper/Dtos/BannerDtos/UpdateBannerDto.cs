using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.BannerDtos
{
    public class UpdateBannerDto
    {        
        public int BannerId { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "Başlık en fazla 50 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }

        [MaxLength(100, ErrorMessage = "Ikon bilgisi en fazla 100 karakter olabilir.")]
        public string? Icon { get; set; }
    }
}
