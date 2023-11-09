using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychologistWorkingDateAndTimeController : ControllerBase
    {
        private readonly IPsychologistWorkingDateAndTimeService _tiemService;

        public PsychologistWorkingDateAndTimeController(IPsychologistWorkingDateAndTimeService tiemService)
        {
            _tiemService = tiemService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAll()
        {
            return await _tiemService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditPsychologistWorkingDateAndTime>> Get([FromRoute] int id)
        {
            return await _tiemService.GetAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromBody] CreatePsychologistWorkingDateAndTime command)
        {
            return await _tiemService.CreateAsync(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromBody] EditPsychologistWorkingDateAndTime command)
        {
            return await _tiemService.UpdateAsync(command);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Delete([FromRoute] int id)
        {
            return await _tiemService.DeleteAsync(id);
        }
    }
}
