using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.BannerDtos;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<ResultAboutDto>> GetAllAsync();
        Task<GetByIdAboutDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutDto createAboutDto);
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAsync(int id);
    }
}
