using Microsoft.AspNetCore.SignalR;

namespace Psychology.Controllers.Chat;

public class PsychologistConversation : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    //public async Task SendFile(IFormFile file)
    //{
    //    // Process the received file on the server side
    //    // In this example, we are just broadcasting the file name to all clients
    //    await Clients.All.SendAsync("ReceiveFile");
    //}
}