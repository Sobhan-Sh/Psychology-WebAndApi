using Microsoft.AspNetCore.Mvc;
using PC.Service.IService.IMessageService;

namespace Psychology.Areas.Admin.ViewComponents;

public class MessagesViewComponent : ViewComponent
{
    private readonly IMessageService _messageService;

    public MessagesViewComponent(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int Id)
    {
        //BaseResult<List<MessageViewModel>> result = await _messageService.GetAllAsync(new SearchMessageViewModel()
        //{
        //    PsychologistId = Id
        //});
        //return View("_Messages", result.Data);
        return View("_Messages");
    }
}