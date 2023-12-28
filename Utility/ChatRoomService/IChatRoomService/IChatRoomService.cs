namespace PC.Utility.ChatRoomService.IChatRoomSerive;

public interface IChatRoomService
{
    Task<string> Get(int PatientId, int PsychologistId);
    Task<string> CreateRoomInChat(int PatientId, int PsychologistId);
}