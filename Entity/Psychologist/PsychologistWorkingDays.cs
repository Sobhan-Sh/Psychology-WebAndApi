using Utility.Domain;

namespace Entity.Psychologist;

public class PsychologistWorkingDays : BaseEntity
{
    public string Day { get; set; }

    public List<PsychologistWorkingDateAndTime> PsychologistWorkingDateAndTimes { get; set; }
}