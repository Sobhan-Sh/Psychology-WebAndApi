using Utility.Domain;

namespace Entity.Patient;

public class Comment : BaseEntity
{
    public string? Title { get; set; }
    public string Text { get; set; }
}