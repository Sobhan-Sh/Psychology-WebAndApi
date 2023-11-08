﻿using System.ComponentModel.DataAnnotations;

namespace Utility.Domain;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required]
    public bool IsActive { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
}
public class BaseEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required]
    public bool IsActive { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
}