using Utility.Dto;

namespace Dto.Patient.PatientResponsesExams;

public class PatientResponsesExams_Test : BaseDto
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public List<PatientResponsesExams_Question> Questions { get; set; }
}