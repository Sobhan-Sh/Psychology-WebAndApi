namespace Dto.Patient.PatientResponsesExams;

public class PatientResponsesExams_Question
{
    public string Title { get; set; }

    public int TestId { get; set; }

    public PatientResponsesExams_Answer Answer { get; set; }
}