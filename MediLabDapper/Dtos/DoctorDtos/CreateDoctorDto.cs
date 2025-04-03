namespace MediLabDapper.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
