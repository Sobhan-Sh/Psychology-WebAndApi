using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;
using PD.Entity.DiscountAndOrder;

namespace PD.Entity.Psychologist;

public class Psychologist : BaseEntity
{
    public string NationalCode { get; set; }

    public string? MedicalLicennseCode { get; set; }

    public int Age { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Commission { get; set; }

    public string? EvidencePath { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User.User User { get; set; }

    public List<PsychologistWorkingDateAndTime> PsychologistWorkingDateAndTime { get; set; }

    public List<Discount> Discount { get; set; }

    public List<Order> Order { get; set; }

    public List<PsychologistTypeOfConsultation> PsychologistTypeOfConsultations { get; set; }

    public void Edit(int age, string nationalCode, string? evidencePath, DateTime? dateOfBirth, string? medicalLicennseCode)
    {
        Age = age;
        NationalCode = nationalCode;
        EvidencePath = evidencePath;
        DateOfBirth = dateOfBirth;
        MedicalLicennseCode = medicalLicennseCode;
        UpdatedAt = DateTime.Now;
    }

    public void Active()
    {
        IsActive = true;
    }

    public void DeActive()
    {
        IsActive = false;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}