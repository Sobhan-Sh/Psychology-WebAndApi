using PC.Utility.ChatRoomService.IChatRoomSerive;

namespace PC.Utility.ChatRoomService;

public class ChatRoomService : IChatRoomService
{
    private readonly Dictionary<int, int> Room = new();

    public async Task<string> Get(int PatientId, int PsychologistId)
    {
        if (Room.ContainsKey(PatientId))
            if (Room[PatientId] == PsychologistId)
                return await Task.FromResult($"{PatientId}{PsychologistId}");

        return await CreateRoomInChat(PatientId, PsychologistId);
    }

    public async Task<string> CreateRoomInChat(int PatientId, int PsychologistId)
    {
        if (Room.ContainsKey(PatientId))
            if (Room[PatientId] == PsychologistId)
                return await Task.FromResult($"{PatientId}{PsychologistId}");

        Room[PatientId] = PsychologistId;
        return await Task.FromResult($"{PatientId}{PsychologistId}");
    }
}