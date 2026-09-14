namespace Exam.App.Services.Dtos.Examinations
{
    public class CreateExaminationDto
    {
        public int PatientId { get; set; }
        public required string VetId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
