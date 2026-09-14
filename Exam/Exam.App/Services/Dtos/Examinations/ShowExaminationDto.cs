namespace Exam.App.Services.Dtos.Examinations
{
    public class ShowExaminationDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        public required string PatientName { get; set; }
        public required string AnimalSpeciesName { get; set; }
        public int PatientAge { get; set; }
    }
}
