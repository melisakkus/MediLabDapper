using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.BannerDtos;
using System.Data;

namespace MediLabDapper.Repositories.BannerRepositories
{
    public class BannerRepository(DapperContext _context) : IBannerRepository
    {
        private readonly IDbConnection _dbConnection = _context.CreateConnection();
        public async Task CreateAsync(CreateBannerDto createBannerDto)
        {
            var query = "insert into Banners (Title,Description,Icon) values (@Title,@Description,@Icon)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createBannerDto.Title);
            parameters.Add("@Description", createBannerDto.Description);
            parameters.Add("@Icon", createBannerDto.Icon);
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from banners where BannerId = @BannerId";
            var parameter = new DynamicParameters();
            parameter.Add("@BannerId", id);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultBannerDto>> GetAllAsync()
        {
            var query = "select * from banners";    
            return await _dbConnection.QueryAsync<ResultBannerDto>(query);
        }

        public Task<GetBannerByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from banners where BannerId = @BannerId";
            var parameters = new DynamicParameters();
            parameters.Add("@BannerId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetBannerByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var query = "update banners set Title=@Title, Description=@Description, Icon=@Icon where BannerId=@BannerId";
            var parameters = new DynamicParameters(updateBannerDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
