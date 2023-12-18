using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Patient.PatientResponses;
using PC.Service.IService.Patient;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PatientResponsesController : ControllerBase
    {
        private readonly IPatientResponsesService _patientResponsesService;

        public PatientResponsesController(IPatientResponsesService patientResponsesService)
        {
            _patientResponsesService = patientResponsesService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PatientResponsesViewModel>>> GetAll()
        {
            return await _patientResponsesService.GetAllAsync();
        }

        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<BaseResult<createPatient>> Get([FromRoute] int id)
        //{
        //    return await _patientResponsesService.GetAsync(id);
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<BaseResult> Create([FromBody] CreatePatient command)
        //{
        //    return await _patientResponsesService.CreateAsync(command);
        //}

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<BaseResult> Edit([FromBody] EditPatient command)
        //{
        //    return await _patientResponsesService.UpdateAsync(command);
        //}

        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<BaseResult> Delete([FromRoute] int id)
        //{
        //    return await _patientResponsesService.DeleteAsync(id);
        //}
    }
}
