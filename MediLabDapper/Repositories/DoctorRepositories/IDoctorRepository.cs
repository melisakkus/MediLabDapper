using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync();
        Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id);
        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto);
        Task DeleteDoctorAsync(int id);


        Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetAllDoctorsWithDepartmentAsync();
    }
}
