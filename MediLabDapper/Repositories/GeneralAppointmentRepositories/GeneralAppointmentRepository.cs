using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.GeneralAppointmentDtos;
using System.Data;

namespace MediLabDapper.Repositories.GeneralAppointmentRepositories
{
    public class GeneralAppointmentRepository : IGeneralAppointmentRepository
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _dbConnection;

        public GeneralAppointmentRepository(DapperContext context)
        {
            _context = context;
            _dbConnection = _context.CreateConnection();
        }

        public async Task CreateAsync(GeneralCreateAppointmentDto createAppointmentDto)
        {
            var query = "insert into Appointments (Date,DepartmentId,DoctorId,Time) values (@Date,@DepartmentId,@DoctorId,@Time)";
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
            var query = "SELECT AppointmentId,Date,Time, Appointments.DoctorId,NameSurname,Appointments.DepartmentId,DepartmentName FROM Appointments INNER JOIN Doctors ON Doctors.DoctorId = Appointments.DoctorId INNER JOIN Departments ON Departments.DepartmentId = Appointments.DepartmentId where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GeneralGetByIdAppointmentDto>(query, parameters);
        }

        public Task UpdateAsync(GeneralUpdateAppointmentDto updateAppointmentDto)
        {
            var query = "update Appointments set Date = @Date, DepartmentId = @DepartmentId, DoctorId = @DoctorId, Time = @Time where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters(updateAppointmentDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }

    }
}
