using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AppointmentDtos;
using System.Data;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public AppointmentRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }

        public async Task CreateAsync(GeneralCreateAppointmentDto createAppointmentDto)
        {
            var query = "insert into Appointments (FullName,Email,Phone,Date,DepartmentId,DoctorId,Message,Time,IsApproved) values (@FullName,@Email,@Phone,@Date,@DepartmentId,@DoctorId,@Message,@Time,@IsApproved)";
            var parameter = new DynamicParameters(createAppointmentDto);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Appointments where AppointmentId = @AppointmentId";
            var parameter = new DynamicParameters();
            parameter.Add("@AppointmentId", id);
            return _dbConnection.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<GeneralResultAppointmentDto>> GetAllAsync()
        {
            var query = "select * from Appointments";
            return _dbConnection.QueryAsync<GeneralResultAppointmentDto>(query);
        }

        public Task<GeneralGetByIdAppointmentDto> GetByIdAsync(int id)
        {
            var query = "select * from Appointments where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GeneralGetByIdAppointmentDto>(query, parameters);
        }

        public Task UpdateAsync(GeneralUpdateAppointmentDto updateAppointmentDto)
        {
            var query = "update Appointments set FullName = @FullName, Email = @Email, Phone = @Phone, Date = @Date, DepartmentId = @DepartmentId, DoctorId = @DoctorId, Message = @Message, Time = @Time , IsApproved = @IsApproved where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters(updateAppointmentDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
