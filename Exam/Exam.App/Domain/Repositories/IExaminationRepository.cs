using System.Diagnostics.Eventing.Reader;

namespace Exam.App.Domain.Repositories
{
    public interface IExaminationRepository
    {
        Task<List<Examination>> GetUpcomingByVetAsync(string vetId);
        Task<Examination?> GetByIdAsync(int id);
        Task<bool> HasConflictAsync(string vetId, DateTime startTime);
        Task<Examination> AddAsync(Examination examination);
        Task<Examination> UpdateAsync(Examination examination);

    }
}
