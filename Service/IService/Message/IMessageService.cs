using PC.Dto.Message;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.IMessageService;

public interface IMessageService
{
    public Task<List<MessageViewModel>> GetAllAsync(SearchMessageViewModel search);

    Task<BaseResult<List<MessagePatientToPschologist>>> GetAllMessagePatientAsync(int Id);
}