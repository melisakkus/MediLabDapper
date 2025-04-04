using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmanRepositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentsAsync();
        Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
