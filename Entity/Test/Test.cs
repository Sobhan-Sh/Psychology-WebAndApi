using Entity.DiscountAndOrder;
using Entity.Patient;
using Utility.Domain;

namespace Entity.Test;

public class Test : BaseEntity
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public List<Question> Question { get; set; }

    public List<PatientExam> PatientExam { get; set; }

    public List<Order> Orders { get; set; }

    public void Edit(string title, string? description)
    {
        Title = title;
        Description = description;
    }

    public void Active()
    {
        IsActive = true;
    }

    public void DeActive()
    {
        IsActive = false;
    }
}