using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.ContactDtos;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ResultContactDto>> GetAllAsync();
        Task<GetByIdContactDto> GetByIdAsync(int id);
        Task CreateAsync(CreateContactDto createBannerDto);
        Task UpdateAsync(UpdateContactDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
