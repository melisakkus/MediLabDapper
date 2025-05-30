using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.GeneralAppointmentDtos
{
    public class GeneralGetByIdAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DepartmentId { get; set; }        
        public int DoctorId { get; set; }
    }
}
