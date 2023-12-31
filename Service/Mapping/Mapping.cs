﻿using PC.Dto.Order;
using PC.Dto.Patient;
using PC.Dto.Patient.PatientResponsesExams;
using PC.Dto.Psychologist;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.User;
using PC.Utility.DateConvertor;
using PD.Entity.DiscountAndOrder;
using PD.Entity.Patient;
using PD.Entity.Psychologist;

namespace PC.Service.Mapping;

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
            IsVisit = turnRepository.Any(x => x.PsychologistWorkingDateAndTimeId == x.Id),
            Day = x.PsychologistWorkingDays.Day
        }).ToList();
    }


    public static List<ListPatientViewModel> ConvertPatientToListPatientViewModelMapping(List<Patient> patient, List<PatientTurn> patientTurns)
    {
        return patient.Select(x => new ListPatientViewModel()
        {
            FName = x.User.FName,
            LName = x.User.LName,
            CreateDateTime = x.CreatedAt,
            PatientId = x.Id,
            PsychologistViewModels = ConvertPsychologistToPsychologistViewModel(patientTurns.Where(p => p.PatientId == x.Id).Select(p => p.PsychologistWorkingDateAndTime.Psychologist).ToList()),
            MobailActiveStatus = x.User.MobailActiveStatus,
            NationalCode = x.NationalCode,
            Phone = x.User.Phone,
        }).ToList();
    }

    private static List<PsychologistViewModel> ConvertPsychologistToPsychologistViewModel(List<Psychologist> psychologists)
    {
        return psychologists.Select(x => new PsychologistViewModel()
        {
            Id = x.Id,
            IsActive = x.IsActive,
            IsDeleted = x.IsDeleted,
            CreatedAt = x.CreatedAt.ToString(),
            Age = x.Age,
            NationalCode = x.NationalCode,
            UserViewModel = new UserViewModel
            {
                FName = x.User.FName,
                LName = x.User.LName,
                Id = x.Id
            }
        }).ToList();
    }

    public static List<MyIncome> ConvertPatientTurnToMyIncomesMapping(List<PatientTurn> patientTurns)
    {
        return patientTurns.Select(x => new MyIncome
        {
            Commission = x.PsychologistWorkingDateAndTime.Psychologist.Commission,
            CreatedAt = DateTimeConvertor.ToPersianNumber(DateTimeConvertor.ToFarsi(x.CreatedAt)),
            ConsultationDay = x.ConsultationDay,
            Price = ((x.Price * (int)x.PsychologistWorkingDateAndTime.Psychologist.Commission) / 100) - x.Price,
        }).ToList();
    }

    public static List<OrderViewModel> ConvertOrderToOrderViewModels(List<Order> orders)
    {
        return orders.Select(x => new OrderViewModel()
        {
            Id = x.Id,
            ConsultationDay = ConvertConsultationToDateTime(x.PatientTurn.ConsultationDay, x.PatientTurn.PsychologistWorkingDateAndTime.PsychologistWorkingHours.EndTime.Hour),
            TotalAmount = x.TotalAmount,
            DiscountAmount = x.DiscountAmount,
            PayAmount = x.PayAmount,
            IsPaid = x.IsPaid,
            PatientTurnViewModel = new()
            {
                IsCanseled = x.PatientTurn.IsCanseled
            },
            PsychologistViewModel = new()
            {
                UserViewModel = new()
                {
                    GenderViewModel = new()
                    {
                        Name = x.Psychologist.User.Gender.Name
                    },
                    LName = x.Psychologist.User.LName,
                    FName = x.Psychologist.User.FName
                },
                Id = x.Psychologist.Id
            }
        }).ToList();
    }

    private static DateTime ConvertConsultationToDateTime(string consultationDay, int hour)
    {
        DateTime date = DateTimeConvertor.ToMiladi(consultationDay);
        return new DateTime(date.Year, date.Month, date.Day, hour, 0, 0, 0);
    }

    public static PsychologistViewModel ConvertPsychologistToPsychologistViewModel(Psychologist psychologist)
    {
        return new PsychologistViewModel()
        {
            UserViewModel = new UserViewModel()
            {
                Id = psychologist.User.Id,
                LName = psychologist.User.LName,
                FName = psychologist.User.FName,
                GenderViewModel = new()
                {
                    Name = psychologist.User.Gender.Name,
                }
            },
            Age = psychologist.Age,
            Id = psychologist.Id
        };
    }
}