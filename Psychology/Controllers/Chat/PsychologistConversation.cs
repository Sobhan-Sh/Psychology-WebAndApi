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
        await Groups.AddToGroupAsync(Context.ConnectionId, NameRoom);
    }

    public async Task SendMessage(List<int> Room, string message, string commentId)
    {
        await Clients.Group(await _chatRoomService.Get(Room[0], Room[1])).SendAsync("ReceiveMessage", message, commentId);
    }

    public async Task PrintListFile(List<int> Room, List<string> ListFile, string commentId)
    {
        await Clients.Group(await _chatRoomService.Get(Room[0], Room[1])).SendAsync("ResultPrintListFile", commentId, ListFile);
    }
}