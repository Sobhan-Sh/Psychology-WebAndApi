using Entity.Patient;
using Utility.Domain;

namespace Entity.Psychologist;

public class TypeOfConsultation : BaseEntity
{
    public string Name { get; set; }

    public int Price { get; set; }

    public List<PsychologistTypeOfConsultation> PsychologistTypeOfConsultations { get; set; }

    public List<PatientTurn> PatientTurns { get; set; }

    public void Edit(string name, int price)
    {
        Name = name;
        Price = price;
        UpdatedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}