using Entity.Patient;
using Utility.Domain;

namespace Entity.Psychologist;

public class TypeOfConsultation : BaseEntity
{
    public string Name { get; set; }

    public int Price { get; set; }

    public List<PatientTurn> PatientTurns { get; set; }
}