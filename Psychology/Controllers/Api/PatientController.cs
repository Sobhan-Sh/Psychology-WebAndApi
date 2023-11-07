using Dto.Patient;
using Framework.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Patient;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _timingService;

        public PatientController(IPatientService patientService)
        {
            _timingService = patientService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PatientViewModel>>> GetAll()
        {
            return await _timingService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<PatientViewModel>> Get([FromRoute] int id)
        {
            return await _timingService.GetAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromBody] CreatePatient command)
        {
            return await _timingService.CreateAsync(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromBody] EditPatient command)
        {
            return await _timingService.UpdateAsync(command);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Delete([FromRoute] int id)
        {
            return await _timingService.DeleteAsync(id);
        }
    }
}
