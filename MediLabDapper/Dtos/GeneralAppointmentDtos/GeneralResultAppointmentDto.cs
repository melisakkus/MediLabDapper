using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Dtos.GeneralAppointmentDtos
{
    public class GeneralResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public ResultDepartmentDto DepartmentName { get; set; }
        public ResultDoctorDto NameSurname { get; set; }

    }
}
