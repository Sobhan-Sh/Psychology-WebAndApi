using Microsoft.AspNetCore.SignalR;
using PC.Utility.ChatRoomService.IChatRoomSerive;

namespace Psychology.Controllers.Chat;

public class PsychologistConversation : Hub
{
    private readonly IChatRoomService _chatRoomService;

    public PsychologistConversation(IChatRoomService chatRoomService)
    {
        _chatRoomService = chatRoomService;
    }

    public async Task CreateRoom(List<int> Room)
    {
        string NameRoom = await _chatRoomService.CreateRoomInChat(Room[0], Room[1]);
        // TODO : چک شود اگر 2 تا کلاینت ها رفتند اتاق درست شده پاک شود
        await Groups.AddToGroupAsync(Context.ConnectionId, NameRoom);
    }

    public async Task SendMessage(List<int> Room, string user, string message)
    {
        await Clients.Group(await _chatRoomService.Get(Room[0], Room[1])).SendAsync("ReceiveMessage", user, message);
    }

    public async Task PrintListFile(List<int> Room, List<string> ListFile)
    {
        await Clients.Group(await _chatRoomService.Get(Room[0], Room[1])).SendAsync("ResultPrintListFile", ListFile);
    }
}