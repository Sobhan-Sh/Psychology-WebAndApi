using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;

namespace PD.Entity.Patient;

public class Comment : BaseEntity
{
    public string? Text { get; set; }

    public int FirstUserId { get; set; }
    [ForeignKey("FirstUserId")]
    public User.User User1 { get; set; }
    
    public int LastUserId { get; set; }
    [ForeignKey("LastUserId")]
    [NotMapped]
    public User.User User2 { get; set; }

    public string? ObjPath { get; set; }
}