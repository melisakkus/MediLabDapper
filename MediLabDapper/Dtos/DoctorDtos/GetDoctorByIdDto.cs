﻿namespace MediLabDapper.Dtos.DoctorDtos
{
    public class GetDoctorByIdDto
    {
        public int DoctorId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
