namespace PC.Dto.SendRequestToPayment;

public class CreateRequestZarinPal
{
    public string Phone { get; set; }

    public string Email { get; set; }

    public string CallbackUrl { get; set; }

    public string Data { get; set; }

    public string Description { get; set; }

    public int Amount { get; set; }
}