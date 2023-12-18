using PC.Dto.Message;
using PC.Service.IRepository.Patient;
using PC.Service.IService.IMessageService;
using PC.Utility.ReturnFuncResult;
using PD.Entity.Patient;

namespace PC.Service.Service.Message;

public class MessageService : IMessageService
{
    private readonly ICommentRepository _commentRepository;

    public MessageService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<MessageViewModel>> GetAllAsync(SearchMessageViewModel search)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<List<MessagePatientToPschologist>>> GetAllMessagePatientAsync(int Id)
    {
        IEnumerable<Comment> commet = await _commentRepository.GetAllAsync();

        return null; //commet.ToString();
    }
}