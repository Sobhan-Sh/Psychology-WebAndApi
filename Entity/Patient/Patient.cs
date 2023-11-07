using Entity.DiscountAndOrder;
using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.Patient;

public class Patient : BaseEntity
{
    public string NationalCode { get; set; }

    public int Age { get; set; }

    public string? TheReason { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User.User User { get; set; }

    public List<PatientExam> PatientExam { get; set; }

    public List<PatientFile> PatientFile { get; set; }

    public List<PatientTurn> PatientTurns { get; set; }

    public List<Discount> Discount { get; set; }

    public List<Order> Orders { get; set; }

    public void Edit(string nationalCode, int age)
    {
        NationalCode = nationalCode;
        Age = age;
    }
}