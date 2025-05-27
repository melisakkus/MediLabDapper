using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AppointmentDtos;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<ResultAppointmentDto>> GetAllAsync();
        Task<GetByIdAppointmentDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAppointmentDto createBannerDto);
        Task UpdateAsync(UpdateAboutDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
