using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.User;
using PC.Service.IService.User;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get All Search
        /// </summary>
        /// <param name="SearchUserViewModel"></param>
        /// <returns> BaseResult(List(UserViewModel)) </returns>
        #region Search

        [HttpGet("get-all-search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<UserViewModel>>> GetAll([FromQuery] SearchUserViewModel model)
        {
            return await _userService.GetAllAsync(model);
        }

        #endregion

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(UserViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<UserViewModel>>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(EditUser) </returns>
        #region Get

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditUser>> Get([FromRoute] int id)
        {
            return await _userService.GetAsync(id);
        }

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreateUser"></param>
        /// <returns> BaseResult </returns>
        #region Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromForm] CreateUser command)
        {
            return await _userService.CreateAsync(command);
        }

        #endregion

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="EditUser"></param>
        /// <returns> BaseResult </returns>
        #region Edit

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromForm] EditUser command)
        {
            return await _userService.UpdateAsync(command);
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
            return await _userService.DeleteAsync(id);
        }

        #endregion

        /// <summary>
        /// Block User
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult </returns>
        #region Block

        [HttpPut("block/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Block([FromRoute] int id)
        {
            return await _userService.BlockAsync(id);
        }

        #endregion

        /// <summary>
        /// On Block User
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult </returns>
        #region OnBlock

        [HttpPut("on-block/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> OnBlock([FromRoute] int id)
        {
            return await _userService.OnBlockAsync(id);
        }

        #endregion
    }
}
