using Dto.Psychologist.PsychologistWorkingHours;
using Framework.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PsychologistWorkingHoursController : ControllerBase
    {
        private readonly IPsychologistWorkingHoursService _psychologistWorkingHours;

        public PsychologistWorkingHoursController(IPsychologistWorkingHoursService psychologistWorkingHours)
        {
            _psychologistWorkingHours = psychologistWorkingHours;
        }

        /// <summary>
        /// Get All Search
        /// </summary>
        /// <param name="SearchPsychologistWorkingHours"></param>
        /// <returns> BaseResult(List(PsychologistWorkingHoursViewModel)) </returns>
        #region Search

        [HttpGet("get-all-search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAll([FromQuery] SearchPsychologistWorkingHours model)
        {
            return await _psychologistWorkingHours.GetAllAsync(model);
        }

        #endregion

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(PsychologistWorkingHoursViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAll()
        {
            return await _psychologistWorkingHours.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(EditPsychologistWorkingHours) </returns>
        #region Get

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

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreatePsychologistWorkingHours"></param>
        /// <returns> BaseResult </returns>
        #region Create

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

        #endregion

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="EditPsychologistWorkingHours"></param>
        /// <returns> BaseResult </returns>
        #region Edit

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
            return await _psychologistWorkingHours.DeleteAsync(id);
        }

        #endregion
    }
}
