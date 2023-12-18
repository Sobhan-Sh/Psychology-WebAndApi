using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Patient.PatientTurn;
using PC.Service.IService.Patient;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PatientTurnController : ControllerBase
    {
        private readonly IPatientTurnService _patientTurnService;

        public PatientTurnController(IPatientTurnService patientTurnService)
        {
            _patientTurnService = patientTurnService;
        }

        /// <summary>
        /// Get All Search
        /// </summary>
        /// <param name="SearchPatientTurn"></param>
        /// <returns> BaseResult(List(PatientTurnViewModel)) </returns>
        #region Search

        [HttpGet("get-all-search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PatientTurnViewModel>>> GetAll([FromQuery] SearchPatientTurn model)
        {
            return await _patientTurnService.GetAllAsync(model);
        }

        #endregion

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(PatientTurnViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PatientTurnViewModel>>> GetAll()
        {
            return await _patientTurnService.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(EditPatientTurn) </returns>
        #region Get

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditPatientTurn>> Get([FromRoute] int id)
        {
            return await _patientTurnService.GetAsync(id);
        }

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreatePatientTurn"></param>
        /// <returns> BaseResult </returns>
        #region Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromBody] CreatePatientTurn command)
        {
            return await _patientTurnService.CreateAsync(command);
        }

        #endregion

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="EditPatientTurn"></param>
        /// <returns> BaseResult </returns>
        #region Edit

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromBody] EditPatientTurn command)
        {
            return await _patientTurnService.UpdateAsync(command);
        }

        #endregion

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult </returns>
        #region Delete

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Delete([FromRoute] int id)
        {
            return await _patientTurnService.DeleteAsync(id);
        }

        #endregion
    }
}
