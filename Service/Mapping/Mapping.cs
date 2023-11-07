using Dto.Patient.PatientResponsesExams;
using Entity.Patient;

namespace Service.Mapping;

public static class Mapping
{
    public static PatientExam PatientExamMapping(CreatePatientResponsesExams command)
    {
        return new PatientExam()
        {
            PatientId = (int)command.PatientId,
            TestId = (int)command.TestId
        };
    }

    public static PatientResponses PatientResponsesMapping(CreatePatientResponsesExams command)
    {
        return new PatientResponses()
        {
            IsActive = true,
            CreatedAt = DateTime.Now,
            PathFile = command.PathFile,
            PatientExamId = (int)command.PatientExamId,
            Score = (int)command.Score,
        };
    }
}