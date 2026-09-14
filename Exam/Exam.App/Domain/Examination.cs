namespace Exam.App.Domain
{
    public class Examination
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public required string VetId { get; set; }
        public ApplicationUser Vet { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public ExaminationStatus Status { get; set; } = ExaminationStatus.Scheduled;

        //public string? CancellationReason { get; set }
        //public decimal? ReportWeight { get; set; }
        //public string? ReportAnamnesis { get; set; }
        //public DateTime? ReportCreatedAt { get; set; }
    }
}
