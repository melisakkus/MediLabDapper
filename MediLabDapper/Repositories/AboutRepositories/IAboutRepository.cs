using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.BannerDtos;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<ResultAboutDto>> GetAllAsync();
        Task<GetByIdAboutDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutDto createBannerDto);
        Task UpdateAsync(UpdateAboutDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
