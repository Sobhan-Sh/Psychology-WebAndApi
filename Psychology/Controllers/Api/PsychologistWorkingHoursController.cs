using Dto.Psychologist.PsychologistWorkingHours;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychologistWorkingHoursController : ControllerBase
    {
        private readonly IPsychologistWorkingHoursService _psychologistWorkingHours;

        public PsychologistWorkingHoursController(IPsychologistWorkingHoursService psychologistWorkingHours)
        {
            _psychologistWorkingHours = psychologistWorkingHours;
        }

        [HttpGet("get-all-search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAll([FromQuery] SearchPsychologistWorkingHours model)
        {
            return await _psychologistWorkingHours.GetAllAsync(model);
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAll()
        {
            return await _psychologistWorkingHours.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditPsychologistWorkingHours>> Get([FromRoute] int id)
        {
            return await _psychologistWorkingHours.GetAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromBody] CreatePsychologistWorkingHours command)
        {
            return await _psychologistWorkingHours.CreateAsync(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromBody] EditPsychologistWorkingHours command)
        {
            return await _psychologistWorkingHours.UpdateAsync(command);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Delete([FromRoute] int id)
        {
            return await _psychologistWorkingHours.DeleteAsync(id);
        }
    }
}
