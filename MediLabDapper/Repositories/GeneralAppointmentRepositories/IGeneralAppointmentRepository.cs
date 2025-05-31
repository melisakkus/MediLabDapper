using MediLabDapper.Dtos.GeneralAppointmentDtos;

namespace MediLabDapper.Repositories.GeneralAppointmentRepositories
{
    public interface IGeneralAppointmentRepository
    {
        Task<IEnumerable<GeneralResultAppointmentDto>> GetAllAsync();
        Task<GeneralGetByIdAppointmentDto> GetByIdAsync(int id);
        Task CreateAsync(GeneralCreateAppointmentDto createAppointmentDto);
        Task UpdateAsync(GeneralUpdateAppointmentDto updateAppointmentDto);
        Task DeleteAsync(int id);

    }
}
