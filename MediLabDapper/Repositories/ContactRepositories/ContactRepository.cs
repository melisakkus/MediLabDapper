using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ContactDtos;
using System.Data;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public ContactRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }
        public async Task CreateAsync(CreateContactDto createContactDto)
        {
            var query = "insert into Contacts (Location,Phone,Email) values (@Location,@Phone,@Email)";
            var parameter = new DynamicParameters(createContactDto);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task DeleteAsync(int id)
        {
            var query = "Delete from Contacts where ContactId = @ContactId";
            var parameter = new DynamicParameters();
            parameter.Add("@ContactId", id);
            return _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultContactDto>> GetAllAsync()
        {
            var query = "select * from Contacts";
            return _dbConnection.QueryAsync<ResultContactDto>(query);
        }

        public Task<GetByIdContactDto> GetByIdAsync(int id)
        {
            var query = "select * from Contacts where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var query = "update Contacts set Location = @Location, Phone = @Phone, Email = @Email where ContactId = @ContactId";
            var parameters = new DynamicParameters(updateContactDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
