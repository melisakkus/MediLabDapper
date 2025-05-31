using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        //public int DepartmentId { get; set; }
        //public int DoctorId { get; set; }
        public string? Message { get; set; }
        public AppointmentStatusDto IsApproved { get; set; }


        public string NameSurname { get; set; }
        public string DepartmentName { get; set; }

    }
}
