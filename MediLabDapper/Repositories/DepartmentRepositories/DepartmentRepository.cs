using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmanRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;
        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            string query = "insert into Departments (DepartmentName, Description) values (@DepartmentName, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentName", createDepartmentDto.DepartmentName);
            parameters.Add("@Description", createDepartmentDto.Description);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteDepartmentAsync(int id)
        {
            string query = "delete from Departments where DepartmentId = @DepartmentId";
            //string query = $"delete from Departments where DepartmentId = {id}";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentsAsync()
        {
            string query = "Select * from Departments";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultDepartmentDto>(query);
        }

        public async Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id)
        {
            string query = "select * from departments where DepartmentId=@DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetDepartmentByIdDto>(query, parameters);

        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "update departments set DepartmentName = @DepartmentName, Description = @Description where DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters(updateDepartmentDto);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
