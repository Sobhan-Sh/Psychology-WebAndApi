namespace PC.Utility.Dto;

public class CreateRequestZarinPal
{
    public string Phone { get; set; }

    public string Email { get; set; }

    public string merchant_id { get; set; }

    public string callback_url { get; set; }

    public string Data { get; set; }

    public string description { get; set; }

    public int amount { get; set; }

    public string Authority { get; set; }

    public string[]? metadata { get; set; }
}