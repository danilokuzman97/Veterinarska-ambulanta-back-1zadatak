using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Exam.App.Infrastructure.Database.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly AppDbContext _context;

        public ExaminationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Examination>> GetUpcomingByVetAsync(string vetId)
        {
            return await _context.Examinations
                .Include(e => e.Patient)
                .ThenInclude(p => p.AnimalSpecies)
                .Where(e => e.VetId == vetId && e.StartTime >= DateTime.UtcNow).OrderBy(equals => equals.StartTime)
                .ToListAsync();
        }

        public async Task<Examination?> GetByIdAsync(int id)
        {
            return await _context.Examinations
                .Include(e => e.Patient)
                    .ThenInclude(p => p.AnimalSpecies)
                .Include(e => e.Vet)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> HasConflictAsync(string vetId, DateTime startTime)
        {
            var requestedEnd = startTime.AddMinutes(20);

            return await _context.Examinations.AnyAsync(e =>
                e.VetId == vetId &&
                e.Status == ExaminationStatus.Scheduled &&
                e.StartTime < requestedEnd &&
                startTime < e.StartTime.AddMinutes(20));
        }

        public async Task<Examination> AddAsync(Examination examination)
        {
            _context.Examinations.Add(examination);
            await _context.SaveChangesAsync();
            return examination;
        }

        public async Task<Examination> UpdateAsync(Examination examination)
        {
            _context.Examinations.Update(examination);
            await _context.SaveChangesAsync();
            return examination;
        }

    }
}