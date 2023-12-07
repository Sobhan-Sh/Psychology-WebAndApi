namespace Dto.Psychologist.PsychologistWorkingDateAndTime;

public class CheckDateVisit
{
    public int Id { get; set; }

    public string StartTime { get; set; }

    public string EndTime { get; set; }

    public bool IsVisit { get; set; }

    public string Day { get; set; }
}