using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos.Examinations;
using Exam.App.Services.Exceptions;

namespace Exam.App.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public ExaminationService(
            IExaminationRepository examinationRepository,
            IPatientRepository patientRepository,
            IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<ShowExaminationDto>> GetUpcomingByVetAsync(string vetId)
        {
            var examinations = await _examinationRepository.GetUpcomingByVetAsync(vetId);
            return examinations.Select(e => _mapper.Map<ShowExaminationDto>(e)).ToList();
        }

        public async Task<ShowExaminationDto> CreateAsync(CreateExaminationDto dto)
        {
            var startTimeUtc = DateTime.SpecifyKind(dto.StartTime, DateTimeKind.Utc);

            var patient = await _patientRepository.GetByIdAsync(dto.PatientId);
            if (patient == null)
                throw new NotFoundException(dto.PatientId);

            if (patient.VetId != dto.VetId)
                throw new BadRequestException("Odabrani pacijent nije dodeljen ovom veterinaru.");

            var hasConflict = await _examinationRepository.HasConflictAsync(dto.VetId, startTimeUtc);
            if (hasConflict)
                throw new BadRequestException("Veterinar nije dostupan u izabranom terminu.");

            var examination = new Examination
            {
                PatientId = dto.PatientId,
                VetId = dto.VetId,
                StartTime = startTimeUtc
            };

            var created = await _examinationRepository.AddAsync(examination);

            var fullyLoaded = await _examinationRepository.GetByIdAsync(created.Id);
            return _mapper.Map<ShowExaminationDto>(fullyLoaded);
        }
    }
}