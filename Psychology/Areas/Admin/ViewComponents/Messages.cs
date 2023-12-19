using Microsoft.AspNetCore.Mvc;

namespace Psychology.Areas.Admin.ViewComponents;

public class MessagesViewComponent : ViewComponent
{

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