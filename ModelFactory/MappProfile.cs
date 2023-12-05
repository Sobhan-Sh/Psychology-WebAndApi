using AutoMapper;
using Dto.account;
using Dto.Discount;
using Dto.Order;
using Dto.Patient;
using Dto.Patient.PatientFile;
using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.Psychologist.PsychologistWorkingDays;
using Dto.Psychologist.PsychologistWorkingHours;
using Dto.Psychologist.TypeOfConsultation;
using Dto.Role;
using Dto.Test;
using Dto.Test.Answer;
using Dto.Test.Question;
using Dto.User;
using Dto.User.Gender;
using Entity.DiscountAndOrder;
using Entity.Patient;
using Entity.Psychologist;
using Entity.Role;
using Entity.Test;
using Entity.User;

namespace ModelFactory;

public class MappProfile : Profile
{
    public static MapperConfiguration RegisterMapp()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            #region Account

            config.CreateMap<RoleViewModel, Role>().ReverseMap();

            config.CreateMap<Register, User>().ReverseMap();


            #endregion

            #region Test

            // test => create
            #region Test (Create)

            // test
            config.CreateMap<CreateTest, Test>()

                .ReverseMap();
            // question

            config.CreateMap<CreateQuestion, Question>()
                /*.ForMember(x => x.Answer, x => x.MapFrom(sub => sub.CreateAnswer))*/.ReverseMap();
            // answer
            config.CreateMap<CreateAnswer, Answer>().ReverseMap();

            #endregion
            // test => edit
            #region Test (Edit)

            // test
            config.CreateMap<EditTest, Test>()
                /*.ForMember(x => x.Question, x => x.MapFrom(sub => sub.CreateQuestion))*/.ReverseMap();
            // question
            config.CreateMap<EditQuestion, Question>()
                /*.ForMember(x => x.Answer, x => x.MapFrom(sub => sub.CreateAnswer))*/.ReverseMap();
            // answer
            config.CreateMap<EditAnswer, Answer>().ReverseMap();

            #endregion
            // test => view model
            #region Test (ViewModel)

            // test
            config.CreateMap<TestViewModel, Test>()
                .ForMember(x => x.Question, x => x.MapFrom(sub => sub.QuestionViewModel)).ReverseMap();
            // question
            config.CreateMap<QuestionViewModel, Question>()
                .ForMember(x => x.Answer, x => x.MapFrom(sub => sub.AnswerViewModels))
                .ReverseMap();
            // answer
            config.CreateMap<AnswerViewModel, Answer>().ReverseMap();

            #endregion

            config.CreateMap<QuestionViewModel, CreateQuestion>().ReverseMap();

            config.CreateMap<AnswerViewModel, CreateAnswer>().ReverseMap();

            #endregion

            #region Patient

            #region File

            config.CreateMap<CreatePatientFile, PatientFile>().ReverseMap();
            config.CreateMap<PatientFileViewModel, PatientFile>().ReverseMap();

            #endregion

            #region Patient

            config.CreateMap<CreatePatient, Patient>().ReverseMap();
            config.CreateMap<PatientViewModel, Patient>().ReverseMap();
            config.CreateMap<EditPatient, Patient>().ReverseMap();

            #endregion

            #region PatientTurn

            config.CreateMap<CreatePatientTurn, PatientTurn>();

            config.CreateMap<PatientTurnViewModel, PatientTurn>()
                .ForMember(x => x.PsychologistWorkingDateAndTime, x => x.MapFrom(sub => sub.PsychologistWorkingDateAndTimeViewModel))
                .ForMember(x => x.Patient, x => x.MapFrom(sub => sub.PatientViewModel))
                .ForMember(x => x.TypeOfConsultation, x => x.MapFrom(sub => sub.TypeOfConsultationViewModel))
                .ForMember(x => x.Order, x => x.MapFrom(sub => sub.OrderViewModels))
                .ReverseMap();

            #endregion

            #endregion

            #region User

            config.CreateMap<CreateUser, User>()
                .ForMember(x => x.GenderId, x => x.MapFrom(sub => sub.GenderId))
                .ReverseMap();

            config.CreateMap<UserViewModel, User>()
                .ForMember(x => x.Role, x => x.MapFrom(sub => sub.RoleViewModel))
                .ForMember(x => x.Gender, x => x.MapFrom(sub => sub.GenderViewModel))
                .ForMember(x => x.Psychologists, x => x.MapFrom(sub => sub.PsychologistViewModels))
                .ReverseMap();

            config.CreateMap<EditUser, User>()
                .ForMember(x => x.GenderId, x => x.MapFrom(sub => sub.GenderId))
                .ReverseMap();

            #region Gender

            config.CreateMap<GenderViewModel, Gender>()
                .ForMember(x => x.Users, x => x.MapFrom(sub => sub.UsersViewModels))
                .ReverseMap();

            #endregion

            #endregion

            #region Psychology

            #region Psychologist

            config.CreateMap<CreatePsychologist, Psychologist>().ReverseMap();
            config.CreateMap<EditPsychologist, Psychologist>().ReverseMap();
            config.CreateMap<PsychologistViewModel, Psychologist>()
                .ForMember(x => x.Order, x => x.MapFrom(sub => sub.OrderViewModels))
                .ForMember(x => x.Discount, x => x.MapFrom(sub => sub.DiscountViewModels))
                .ForMember(x => x.User, x => x.MapFrom(sub => sub.UserViewModel))
                .ForMember(x => x.PsychologistWorkingDateAndTime, x => x.MapFrom(sub => sub.PsychologistWorkingDateAndTimeViewModels))
                .ReverseMap();

            #endregion

            #region PsychologistWorkingDateAndTime

            config.CreateMap<CreatePsychologistWorkingDateAndTime, PsychologistWorkingDateAndTime>().ReverseMap();
            config.CreateMap<EditPsychologistWorkingDateAndTime, PsychologistWorkingDateAndTime>().ReverseMap();
            config.CreateMap<PsychologistWorkingDateAndTimeViewModel, PsychologistWorkingDateAndTime>()
                .ForMember(x => x.PsychologistWorkingDays, x => x.MapFrom(sub => sub.PsychologistWorkingDaysViewModel))
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ForMember(x => x.PsychologistWorkingHours, x => x.MapFrom(sub => sub.PsychologistWorkingHoursViewModel))
                .ForMember(x => x.PatientTurns, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ReverseMap();

            #endregion

            #region PsychologistWorkingDays

            config.CreateMap<CreatePsychologistWorkingDays, PsychologistWorkingDays>().ReverseMap();

            config.CreateMap<PsychologistWorkingDaysViewModel, PsychologistWorkingDays>()
                .ForMember(x => x.PsychologistWorkingDateAndTimes, x => x.MapFrom(sub => sub.PsychologistWorkingDateAndTimeViewModels))
                .ReverseMap();

            #endregion

            #region PsychologistWorkingHours

            config.CreateMap<CreatePsychologistWorkingHours, PsychologistWorkingHours>().ReverseMap();
            config.CreateMap<PsychologistWorkingHoursViewModel, PsychologistWorkingHours>()
                .ForMember(x => x.PsychologistWorkingDateAndTimes, x => x.MapFrom(sub => sub.PsychologistWorkingDateAndTimeViewModels))
                .ReverseMap();

            #endregion

            #region TypeOfConsultation

            config.CreateMap<CreateTypeOfConsultation, TypeOfConsultation>().ReverseMap();
            config.CreateMap<EditTypeOfConsultation, TypeOfConsultation>().ReverseMap();
            config.CreateMap<TypeOfConsultationViewModel, TypeOfConsultation>()
                .ForMember(x => x.PatientTurns, x => x.MapFrom(sub => sub.PatientTurnViewModels))
                .ReverseMap();

            #endregion

            #endregion

            #region DiscountAndOrder

            #region Order

            config.CreateMap<CreateOrder, Order>().ReverseMap();

            config.CreateMap<OrderViewModel, Order>()
                .ForMember(x => x.PatientTurn, x => x.MapFrom(sub => sub.PatientTurnViewModel))
                .ForMember(x => x.Test, x => x.MapFrom(sub => sub.TestViewModel))
                .ForMember(x => x.Patient, x => x.MapFrom(sub => sub.PatientViewModel))
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ReverseMap();

            #endregion

            #region Discount

            config.CreateMap<CreateDiscount, Discount>().ReverseMap();

            config.CreateMap<DiscountViewModel, Discount>()
                .ForMember(x => x.Patient, x => x.MapFrom(sub => sub.PatientViewModel))
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ReverseMap();

            #endregion

            #endregion
        });

        return mappingConfig;
    }
}