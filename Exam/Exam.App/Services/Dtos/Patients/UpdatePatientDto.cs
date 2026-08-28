namespace Exam.App.Services.Dtos.Patients
{
    public class UpdatePatientDto
    {
        public required string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public DateOnly BirthDate { get; set; }

        public required string VetId { get; set; } // id odabranog veta

        //namerno nema owvera, nema opcije izmene istog
    }
}
