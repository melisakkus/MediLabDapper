using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AppointmentDtos;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<GeneralResultAppointmentDto>> GetAllAsync();
        Task<GeneralGetByIdAppointmentDto> GetByIdAsync(int id);
        Task CreateAsync(GeneralCreateAppointmentDto createAppointmentDto);
        Task UpdateAsync(GeneralUpdateAppointmentDto updateAppointmentDto);
        Task DeleteAsync(int id);
    }
}
