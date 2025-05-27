using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using System.Data;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public AboutRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }

        public async Task CreateAsync(CreateAboutDto createAboutDto)
        {
            var query = "insert into Abouts (Description,Title1,Explanation1,Title2,Explanation2,Title3,Explanation3) values (@Description,@Title1,@Explanation1,@Title2,@Explanation2,@Title3,@Explanation3)";
            var parameter = new DynamicParameters(createAboutDto);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task DeleteAsync(int id)
        {
           var query = "delete form Abouts where AboutId = @AboutId";
            var parameter = new DynamicParameters();
            parameter.Add("@AboutId", id);
            return _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultAboutDto>> GetAllAsync()
        {
            var query = "select * from Abouts";
            return _dbConnection.QueryAsync<ResultAboutDto>(query);
        }

        public Task<GetByIdAboutDto> GetByIdAsync(int id)
        {
            var query = "select * from Abouts where AboutId = @AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetByIdAboutDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var query = "update Abouts set Description = @Description, Title1 = @Title1, Explanation1 = @Explanation1, Title2 = @Title2, Explanation2 = @Explanation2, Title3 = @Title3, Explanation3 = @Explanation3 where AboutId = @AboutId";
            var parameters = new DynamicParameters(updateAboutDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
