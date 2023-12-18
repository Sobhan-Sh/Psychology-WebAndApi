using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;
using PD.Entity.Patient;

namespace PD.Entity.Psychologist;

public class PsychologistWorkingDateAndTime : BaseEntity
{
    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist Psychologist { get; set; }

    public int PsychologistWorkingDaysId { get; set; }
    [ForeignKey("PsychologistWorkingDaysId")]
    public PsychologistWorkingDays PsychologistWorkingDays { get; set; }

    public int PsychologistWorkingHoursId { get; set; }
    [ForeignKey("PsychologistWorkingHoursId")]
    public PsychologistWorkingHours PsychologistWorkingHours { get; set; }

    public List<PatientTurn> PatientTurns { get; set; }

    public void Edit(int psychologistWorkingHoursId, int psychologistWorkingDaysId)
    {
        PsychologistWorkingDaysId = psychologistWorkingDaysId;
        PsychologistWorkingHoursId = psychologistWorkingHoursId;
        UpdatedAt = DateTime.Now;
    }
}