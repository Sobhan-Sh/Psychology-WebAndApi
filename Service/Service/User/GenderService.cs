using AutoMapper;
using Dto.User.Gender;
using Entity.User;
using Service.IRepository.User;
using Service.IService.User;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.User;

public class GenderService : IGenderService
{
    private readonly IGenderRepository _genderRepository;
    private IMapper _mapper;

    public GenderService(IGenderRepository genderRepository, IMapper mapper)
    {
        _genderRepository = genderRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<GenderViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Gender> query = await _genderRepository.GetAllAsync(include: "Users");
            if (!query.Any())
            {
                return new BaseResult<List<GenderViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<GenderViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<GenderViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<GenderViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}