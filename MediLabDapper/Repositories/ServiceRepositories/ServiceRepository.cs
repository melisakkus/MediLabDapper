using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ServiceDtos;
using System.Data;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public ServiceRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }
        public async Task CreateAsync(CreateServiceDto createServiceDto)
        {
            var query = "insert into Services (Title,Icon,Explanation) values (@Title,@Icon,@Explanation)";
            var parameter = new DynamicParameters(createServiceDto);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Services where ServiceId = @ServiceId";
            var parameter = new DynamicParameters();
            parameter.Add("@ServiceId", id);
            return _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultServiceDto>> GetAllAsync()
        {
            var query = "select * from Services";
            return _dbConnection.QueryAsync<ResultServiceDto>(query);
        }

        public Task<GetByIdServiceDto> GetByIdAsync(int id)
        {
            var query = "select * from Services where ServiceId = @ServiceId";
            var parameter = new DynamicParameters();
            parameter.Add("@ServiceId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameter);
        }

        public Task UpdateAsync(UpdateServiceDto updateServiceDto)
        {
            var query = "update Services set Title = @Title, Icon = @Icon, Explanation = @Explanation where ServiceId = @ServiceId";
            var parameters = new DynamicParameters(updateServiceDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
