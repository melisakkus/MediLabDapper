namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public string? Message { get; set; }
        public bool IsApproved { get; set; }
    }
}
