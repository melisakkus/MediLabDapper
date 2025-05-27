namespace MediLabDapper.Dtos.BannerDtos
{
    public class GetBannerByIdDto
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
