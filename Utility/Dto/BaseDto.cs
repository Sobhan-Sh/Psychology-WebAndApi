namespace Utility.Dto;
public class BaseDto
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public string CreatedAt { get; set; }

    public string? Updated { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
public class BaseDto<TKey>
{
    public TKey Id { get; set; }

    public DateTime Created { get; set; }

    public string CreatedAt { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}