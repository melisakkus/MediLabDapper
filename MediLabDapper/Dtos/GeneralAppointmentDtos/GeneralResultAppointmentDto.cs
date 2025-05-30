namespace MediLabDapper.Dtos.GeneralAppointmentDtos
{
    public class GeneralResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }

    }
}
