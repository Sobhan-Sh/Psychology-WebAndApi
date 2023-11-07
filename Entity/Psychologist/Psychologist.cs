using Entity.DiscountAndOrder;
using Utility.Domain;

namespace Entity.Psychologist;

public class Psychologist : BaseEntity
{
    public string NationalCode { get; set; }

    public string? MedicalLicennseCode { get; set; }

    public int Age { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Commission { get; set; }

    public string? EvidencePath { get; set; }

    public List<PsychologistWorkingDateAndTime> PsychologistWorkingDateAndTime { get; set; }

    public List<Discount> Discount { get; set; }

    public List<Order> Order { get; set; }
}