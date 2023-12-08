namespace Dto.Patient.PatientTurn;

public class SetVisitModel
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public int TypeOfConsultationId { get; set; }

    public int PsychologistId { get; set; }

    public int TimeId { get; set; }

    public string DateTimeVisit { get; set; }
}