namespace Exam.App.Services.Dtos.Patients
{
    public class CreatePatientDto
    {
        public required string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public DateOnly BirthDate { get; set; }

        public required string OwnerUsername { get; set; }

        public required string VetId { get; set; }
    }
}
