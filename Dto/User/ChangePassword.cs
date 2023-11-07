namespace Dto.User;

public class ChangePassword
{
    public int Id { get; set; }

    public string Password { get; set; }
    public string NewPassword { get; set; }

    public string ConfirmNewPassword { get; set; }
}