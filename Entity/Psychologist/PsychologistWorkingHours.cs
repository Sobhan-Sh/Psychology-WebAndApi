using PC.Utility.Domain;

namespace PD.Entity.Psychologist;

public class PsychologistWorkingHours : BaseEntity
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public List<PsychologistWorkingDateAndTime> PsychologistWorkingDateAndTimes { get; set; }

    public void Edit(DateTime startTime, DateTime endTime)
    {
        EndTime = endTime;
        StartTime = startTime;
        UpdatedAt = DateTime.Now;
    }
}