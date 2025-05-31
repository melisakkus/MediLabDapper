using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.TestimonialDtos;
using System.Data;

namespace MediLabDapper.Repositories.TestimonialRepositories
{
    public class TestimonialRepository: ITestimonialRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public TestimonialRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }

        public async Task CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            var query = "insert into Testimonials (Comment,FullName,Review,JobTitle,ImageUrl) values (@Comment,@FullName,@Review,@JobTitle,@ImageUrl)";
            var parameter = new DynamicParameters(createTestimonialDto);
            await _dbConnection.ExecuteAsync(query,parameter);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Testimonials where TestimonialId = @TestimonialId";
            var parameter = new DynamicParameters();
            parameter.Add("@TestimonialId", id);
            return _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            var query = "select * from Testimonials";
            return _dbConnection.QueryAsync<ResultTestimonialDto>(query);
        }

        public Task<GetByIdTestimonialDto> GetByIdAsync(int id)
        {
            var query = "select * from testimonials where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var query = "update Testimonials set Comment = @Comment, FullName = @FullName, Review = @Review, JobTitle = @JobTitle, ImageUrl=@ImageUrl where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters(updateTestimonialDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
