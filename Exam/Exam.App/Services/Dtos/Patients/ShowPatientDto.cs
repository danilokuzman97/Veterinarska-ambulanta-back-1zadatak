namespace Exam.App.Services.Dtos.Patients
{
    public class ShowPatientDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }

        public required string AnimalSpecies { get; set; }
        public required string OwnerFullName { get; set; }
        public required string VetFullName { get; set; }

    }
}
