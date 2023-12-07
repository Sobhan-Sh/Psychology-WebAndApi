using Dto.Patient.PatientResponsesExams;
using Dto.Psychologist.PsychologistTypeOfConsultation;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Entity.Patient;
using Entity.Psychologist;

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

    public static List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel> ConvertPsychologistToNewModelPsychologistTypeOfConsultationInPageVisitViewModelMapping(List<PsychologistTypeOfConsultation> psychologistTypeOfConsultations)
    {
        return psychologistTypeOfConsultations.Select(x => new NewModelPsychologistTypeOfConsultationInPageVisitViewModel()
        {
            Id = x.PsychologistId,
            TagSelectFullName = $"{x.Psychologist.User.Gender.Name.Replace("آقا", "آقای")} دکتر {x.Psychologist.User.FName} {x.Psychologist.User.LName}"
        }).ToList();
    }

    public static List<CheckDateVisit> ConvertPsychologistWorkingDateAndTimeToCheckDateVisitMapping(
        List<PsychologistWorkingDateAndTime> psychologistWorkingDateAndTimes, List<PatientTurn> turnRepository)
    {
        return psychologistWorkingDateAndTimes.Select(x => new CheckDateVisit()
        {
            Id = x.Id,
            EndTime = x.PsychologistWorkingHours.EndTime.ToString("hh"),
            StartTime = x.PsychologistWorkingHours.StartTime.ToString("hh"),
            IsVisit = turnRepository.Any(x =>  x.PsychologistWorkingDateAndTimeId == x.Id),
            Day = x.PsychologistWorkingDays.Day
        }).ToList();
    }
}