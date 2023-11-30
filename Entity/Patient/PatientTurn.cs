using Entity.DiscountAndOrder;
using Entity.Psychologist;
using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.Patient;

public class PatientTurn : BaseEntity
{
    public int PsychologistWorkingDateAndTimeId { get; set; }
    [ForeignKey("PsychologistWorkingDateAndTimeId")]
    public PsychologistWorkingDateAndTime PsychologistWorkingDateAndTime { get; set; }

    public int TypeOfConsultationId { get; set; }
    [ForeignKey("TypeOfConsultationId")]
    public TypeOfConsultation TypeOfConsultation { get; set; }

    public List<Order> Order { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    public DateTime ConsultationDay { get; set; }

    public int Price { get; set; }

    public bool IsVisited { get; set; }

    public bool IsCanseled { get; set; }

    public void Edit(int? price, DateTime consultationDay, int typeOfConsultationId, int psychologistWorkingDateAndTimeId)
    {
        Price = (int)price;
        ConsultationDay = consultationDay;
        TypeOfConsultationId = typeOfConsultationId;
        PsychologistWorkingDateAndTimeId = psychologistWorkingDateAndTimeId;
    }

    public void Visited()
    {
        IsVisited = true;
        UpdatedAt = DateTime.Now;
    }

    public void Canseled()
    {
        IsCanseled = true;
        UpdatedAt = DateTime.Now;
    }
}