﻿using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Dtos.GeneralAppointmentDtos;
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

        public async Task CreateAsync(CreateAppointmentDto createAppointmentDto)
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

        public Task<IEnumerable<ResultAppointmentDto>> GetAllAsync()
        {
            var query = "select * from Appointments";
            return _dbConnection.QueryAsync<ResultAppointmentDto>(query);
        }

        public Task<GetByIdAppointmentDto> GetByIdAsync(int id)
        {
            var query = "select * from Appointments where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _dbConnection.QueryFirstOrDefaultAsync<GetByIdAppointmentDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateAppointmentDto updateAppointmentDto)
        {
            var query = "update Appointments set FullName = @FullName, Email = @Email, Phone = @Phone, Date = @Date, DepartmentId = @DepartmentId, DoctorId = @DoctorId, Message = @Message, Time = @Time , IsApproved = @IsApproved where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters(updateAppointmentDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }

        public Task<IEnumerable<ResultAppointmentDto>> GetAppointmentsWDocWDep()
        {
            var query = "SELECT AppointmentId,FullName,Email,Phone,Date,Time,IsApproved,NameSurname,DepartmentName FROM Appointments INNER JOIN Doctors ON Doctors.DoctorId = Appointments.DoctorId INNER JOIN Departments ON Departments.DepartmentId = Appointments.DepartmentId";
            return _dbConnection.QueryAsync<ResultAppointmentDto>(query);
        }

        public Task<IEnumerable<ResultAppointmentDto>> GetAvailableAppointmentsWDocWDep(int departmentId, int doctorId)
        {
            var query = "SELECT AppointmentId,FullName,Email,Phone,Date,Time,IsApproved,NameSurname,DepartmentName FROM Appointments INNER JOIN Doctors ON Doctors.DoctorId = Appointments.DoctorId INNER JOIN Departments ON Departments.DepartmentId = Appointments.DepartmentId where Appointments.DoctorId = @doctorId and Appointments.DepartmentId=@departmentId  and (Appointments.FullName IS NULL OR Appointments.FullName = '') ";
            var parameters = new DynamicParameters();
            parameters.Add("@doctorId", doctorId);
            parameters.Add("@departmentId", departmentId);
            return _dbConnection.QueryAsync<ResultAppointmentDto>(query,parameters);
        }

        public async Task UpdateAppointmentWithUserInfo(int appointmentId, CreateAppointmentDto dto)
        {
            var query = @"UPDATE Appointments 
                  SET FullName = @FullName, 
                      Email = @Email, 
                      Phone = @Phone, 
                      Message = @Message,
                      IsApproved = 0
                  WHERE AppointmentId = @AppointmentId";

            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", appointmentId);
            parameters.Add("@FullName", dto.FullName);
            parameters.Add("@Email", dto.Email);
            parameters.Add("@Phone", dto.Phone);
            parameters.Add("@Message", dto.Message);

            await _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
