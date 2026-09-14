using Exam.App.Services;
using Exam.App.Services.Dtos.Examinations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Exam.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Pomocnik")]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        public ExaminationsController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingByVet([FromQuery] string vetId)
        {
            return Ok(await _examinationService.GetUpcomingByVetAsync(vetId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExaminationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _examinationService.CreateAsync(dto);
            return Ok(created);
        }

    }
}
