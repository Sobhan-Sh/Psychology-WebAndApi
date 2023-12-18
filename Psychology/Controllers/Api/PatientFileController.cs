using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Patient.PatientFile;
using PC.Service.IService.Patient;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PatientFileController : ControllerBase
    {
        private readonly IPatientFileService _patientFileService;

        public PatientFileController(IPatientFileService patientFileService)
        {
            _patientFileService = patientFileService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(PatientFileViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PatientFileViewModel>>> GetAll()
        {
            return await _patientFileService.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(PatientFileViewModel) </returns>
        #region Get

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<PatientFileViewModel>> Get([FromRoute] int id)
        {
            return await _patientFileService.GetAsync(id);
        }

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreatePatientFile"></param>
        /// <returns> BaseResult </returns>
        #region Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromForm] CreatePatientFile command)
        {
            return await _patientFileService.CreateAsync(command);
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
            return await _patientFileService.DeleteAsync(id);
        }

        #endregion

        /// <summary>
        /// Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult </returns>
        #region Active

        [HttpPut("active/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Active([FromRoute] int id)
        {
            return await _patientFileService.ActiveAsync(id);
        }

        #endregion

        /// <summary>
        /// DeActive
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult </returns>
        #region DeActive

        [HttpPut("de-active/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> DeActive([FromRoute] int id)
        {
            return await _patientFileService.DeActiveAsync(id);
        }

        #endregion
    }
}
