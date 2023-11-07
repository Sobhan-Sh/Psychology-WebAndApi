using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.Test;

public class Question : BaseEntity
{
    [Required]
    public string Title { get; set; }

    public List<Answer> Answer { get; set; }

    public int TestId { get; set; }
    [ForeignKey("TestId")]
    public Test Test { get; set; }

    public void Edit(string title)
    {
        Title = title;
    }
}