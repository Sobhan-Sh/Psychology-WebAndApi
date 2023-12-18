using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Psychologist.PsychologistWorkingDays;
using PC.Service.IService.Psychologist;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class PsychologistWorkingDaysController : ControllerBase
    {
        private readonly IPsychologistWorkingDaysService _sychologistWorkingDaysService;

        public PsychologistWorkingDaysController(IPsychologistWorkingDaysService sychologistWorkingDaysService)
        {
            _sychologistWorkingDaysService = sychologistWorkingDaysService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(PsychologistWorkingDaysViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<PsychologistWorkingDaysViewModel>>> GetAll()
        {
            return await _sychologistWorkingDaysService.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(EditPsychologistWorkingDays) </returns>
        #region Get

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditPsychologistWorkingDays>> Get([FromRoute] int id)
        {
            return await _sychologistWorkingDaysService.GetAsync(id);
        }

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreatePsychologistWorkingDays"></param>
        /// <returns> BaseResult </returns>
        #region Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromBody] CreatePsychologistWorkingDays command)
        {
            return await _sychologistWorkingDaysService.CreateAsync(command);
        }

        #endregion

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="EditPsychologistWorkingDays"></param>
        /// <returns> BaseResult </returns>
        #region Edit

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromBody] EditPsychologistWorkingDays command)
        {
            return await _sychologistWorkingDaysService.UpdateAsync(command);
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
            return await _sychologistWorkingDaysService.DeleteAsync(id);
        }

        #endregion
    }
}
