using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(400, ErrorMessage = "Açıklama en fazla 400 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Başlık 1 boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Başlık 1 en fazla 100 karakter olabilir.")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Açıklama 1 boş bırakılamaz.")]
        [MaxLength(200, ErrorMessage = "Açıklama 1 en fazla 200 karakter olabilir.")]
        public string Explanation1 { get; set; }

        [Required(ErrorMessage = "Başlık 2 boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Başlık 2 en fazla 100 karakter olabilir.")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Açıklama 2 boş bırakılamaz.")]
        [MaxLength(200, ErrorMessage = "Açıklama 2 en fazla 200 karakter olabilir.")]
        public string Explanation2 { get; set; }

        [Required(ErrorMessage = "Başlık 3 boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Başlık 3 en fazla 100 karakter olabilir.")]
        public string Title3 { get; set; }

        [Required(ErrorMessage = "Açıklama 3 boş bırakılamaz.")]
        [MaxLength(200, ErrorMessage = "Açıklama 3 en fazla 200 karakter olabilir.")]
        public string Explanation3 { get; set; }
    }
}
