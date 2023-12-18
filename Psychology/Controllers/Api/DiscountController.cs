using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC.Dto.Discount;
using PC.Service.IService.DiscountAndOrder;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{RoleHelper.Admin}")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        /// <summary>
        /// Get All Search
        /// </summary>
        /// <param name="SearchDiscount"></param>
        /// <returns> BaseResult(List(DiscountViewModel)) </returns>
        #region Search

        [HttpGet("get-all-search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<DiscountViewModel>>> GetAll([FromQuery] SearchDiscount model)
        {
            return await _discountService.GetAllAsync(model);
        }

        #endregion

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns> BaseResult(List(DiscountViewModel)) </returns>
        #region Get All

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<List<DiscountViewModel>>> GetAll()
        {
            return await _discountService.GetAllAsync();
        }

        #endregion

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns> BaseResult(EditDiscount) </returns>
        #region Get

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult<EditDiscount>> Get([FromRoute] int id)
        {
            return await _discountService.GetAsync(id);
        }

        #endregion

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CreateDiscount"></param>
        /// <returns> BaseResult </returns>
        #region Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Create([FromForm] CreateDiscount command)
        {
            return await _discountService.CreateAsync(command);
        }

        #endregion

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="EditDiscount"></param>
        /// <returns> BaseResult </returns>
        #region Edit

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<BaseResult> Edit([FromForm] EditDiscount command)
        {
            return await _discountService.UpdateAsync(command);
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
            return await _discountService.DeleteAsync(id);
        }

        #endregion
    }
}
