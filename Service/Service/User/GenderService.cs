using AutoMapper;
using PC.Dto.User.Gender;
using PC.Service.IRepository.User;
using PC.Service.IService.User;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.User;

namespace PC.Service.Service.User;

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