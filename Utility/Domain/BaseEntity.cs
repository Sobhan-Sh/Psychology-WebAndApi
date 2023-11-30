namespace Utility.Domain;

public class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; } = false;
}

public class BaseEntity<TKey>
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }

    public TKey Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; } = false;

}