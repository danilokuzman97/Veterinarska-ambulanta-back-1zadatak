using Exam.App.Services.Dtos.Examinations;

namespace Exam.App.Services
{
    public interface IExaminationService
    {
        Task<List<ShowExaminationDto>> GetUpcomingByVetAsync(string vetId);
        Task<ShowExaminationDto> CreateAsync(CreateExaminationDto dto);
    }
}