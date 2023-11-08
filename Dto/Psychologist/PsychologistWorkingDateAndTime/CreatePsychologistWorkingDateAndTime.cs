using Dto.Patient.PatientTurn;
using Utility.Dto;

namespace Dto.Psychologist.PsychologistWorkingDateAndTime;

public class CreatePsychologistWorkingDateAndTime : BaseDto
{
    public int PsychologistId { get; set; }

    public int PsychologistWorkingDaysId { get; set; }

    public int PsychologistWorkingHoursId { get; set; }
}