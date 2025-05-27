using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Adres boş bırakılamaz.")]
        [MaxLength(300, ErrorMessage = "Adres en fazla 300 karakter olabilir.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}
