using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.BannerDtos
{
    public class ResultBannerDto
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
