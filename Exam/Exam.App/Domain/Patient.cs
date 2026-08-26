namespace Exam.App.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }

        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; } = null!;

        public required string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; } = null!;

        public required string VetId { get; set; }
        public ApplicationUser Vet { get; set; } = null!;
        
    }
}
