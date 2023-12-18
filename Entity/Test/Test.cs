using PC.Utility.Domain;
using PD.Entity.DiscountAndOrder;
using PD.Entity.Patient;

namespace PD.Entity.Test;

public class Test : BaseEntity
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public int Price { get; set; }

    public List<Question> Question { get; set; }

    public List<PatientExam> PatientExam { get; set; }

    public List<Order> Orders { get; set; }

    public void Edit(string title, string? description, int price)
    {
        Title = title;
        Description = description;
        Price = price;
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