using System.ComponentModel.DataAnnotations;

namespace Utility.Domain;

public class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }

    [Key] public int Id { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required] public bool IsActive { get; set; }
}

public class BaseEntity<TKey>
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }

    [Key] public TKey Id { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required] public bool IsActive { get; set; }
}