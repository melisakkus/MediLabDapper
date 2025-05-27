using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.ServiceDtos;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ResultServiceDto>> GetAllAsync();
        Task<GetByIdServiceDto> GetByIdAsync(int id);
        Task CreateAsync(CreateServiceDto createBannerDto);
        Task UpdateAsync(UpdateServiceDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
