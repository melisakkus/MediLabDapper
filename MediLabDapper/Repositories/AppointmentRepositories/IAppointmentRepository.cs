using MediLabDapper.Dtos.AppointmentDtos;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<ResultAppointmentDto>> GetAllAsync();
        Task<GetByIdAppointmentDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAppointmentDto createAppointmentDto);
        Task UpdateAsync(UpdateAppointmentDto updateAppointmentDto);
        Task DeleteAsync(int id);

        Task<IEnumerable<ResultAppointmentDto>> GetAppointmentsWDocWDep();

    }
}
