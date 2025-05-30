﻿using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using System.Data;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context) : IDoctorRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();
        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            if (createDoctorDto.ImageUrl == null || createDoctorDto.ImageUrl == "")
            {
                createDoctorDto.ImageUrl = "https://i.hizliresim.com/l74tw55.png";
            }

            var query = "insert into Doctors (NameSurname,ImageUrl,Description,DepartmentId) values (@NameSurname,@ImageUrl,@Description,@DepartmentId)";
            var parameters = new DynamicParameters(createDoctorDto);
            //var connection = _db;
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var query = "Delete from Doctors where DoctorId = @DoctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@DoctorId", id);
            await _db.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            var query = "Select * from doctors";
            return await _db.QueryAsync<ResultDoctorDto>(query);
        }

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetAllDoctorsWithDepartmentAsync()
        {
            var query = "Select DoctorId,NameSurname,Doctors.ImageUrl,Doctors.Description,DepartmentName from Doctors inner join departments on Doctors.DepartmentId=Departments.DepartmentId";
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query);
        }

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetAllDoctorsWithDepartmentIdAsync(int departmentId)
        {
            var query = "Select DoctorId,NameSurname,Doctors.ImageUrl,Doctors.Description,DepartmentName from Doctors inner join departments on Doctors.DepartmentId=Departments.DepartmentId where Doctors.DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query,parameters);
        }

        public Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id)
        {
            var query = "select * from doctors where DoctorId=@DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", id);
            return _db.QueryFirstOrDefaultAsync<GetDoctorByIdDto>(query, parameters);
        }

        public Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            if (updateDoctorDto.ImageUrl == null || updateDoctorDto.ImageUrl == "")
            {
                updateDoctorDto.ImageUrl = "https://i.hizliresim.com/l74tw55.png";
            }
            var query = "update doctors set NameSurname=@NameSurname, ImageUrl=@ImageUrl, Description=@Description, DepartmentId=@DepartmentId where DoctorId=@DoctorId";
            var parameters = new DynamicParameters(updateDoctorDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
