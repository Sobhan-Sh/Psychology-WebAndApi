using Utility.Domain;

namespace Entity.Psychologist;

public class PsychologistWorkingHours : BaseEntity
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}