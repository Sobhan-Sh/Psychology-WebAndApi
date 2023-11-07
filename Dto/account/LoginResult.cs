namespace Dto.account;

public class LoginResult
{
    public string Phone { get; set; }

    public string Token { get; set; }

    public string Role { get; set; }

    public int UserId { get; set; }

    public string? Avatar { get; set; }
}