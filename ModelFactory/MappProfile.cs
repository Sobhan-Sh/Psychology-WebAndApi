using AutoMapper;
using PC.Dto.account;
using PC.Dto.Discount;
using PC.Dto.Order;
using PC.Dto.Patient;
using PC.Dto.Patient.PatientFile;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Dto.Psychologist.Article;
using PC.Dto.Psychologist.PsychologistAboutUs;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.Psychologist.PsychologistWorkingDays;
using PC.Dto.Psychologist.PsychologistWorkingHours;
using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Dto.Role;
using PC.Dto.Test;
using PC.Dto.Test.Answer;
using PC.Dto.Test.Question;
using PC.Dto.User;
using PC.Dto.User.Gender;
using PD.Entity.DiscountAndOrder;
using PD.Entity.Patient;
using PD.Entity.Psychologist;
using PD.Entity.Role;
using PD.Entity.Test;
using PD.Entity.User;

namespace PF.ModelFactory;

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
            config.CreateMap<EditPatient, Patient>().ReverseMap();
            config.CreateMap<PatientViewModel, Patient>()
                .ForMember(x => x.User, x => x.MapFrom(sub => sub.UserViewModel))
                .ForPath(x => x.User.Gender, x => x.MapFrom(sub => sub.UserViewModel.GenderViewModel))
                .ReverseMap();

            #endregion

            #region PatientTurn

            config.CreateMap<CreatePatientTurn, PatientTurn>();

            config.CreateMap<PatientTurnViewModel, PatientTurn>()
                .ForMember(x => x.PsychologistWorkingDateAndTime, x => x.MapFrom(sub => sub.PsychologistWorkingDateAndTimeViewModel))
                .ForMember(x => x.Patient, x => x.MapFrom(sub => sub.PatientViewModel))
                .ForPath(x => x.Patient.User, x => x.MapFrom(sub => sub.PatientViewModel.UserViewModel))
                .ForPath(x => x.Patient.User.Gender, x => x.MapFrom(sub => sub.PatientViewModel.UserViewModel.GenderViewModel))
                .ForPath(x => x.TypeOfConsultation, x => x.MapFrom(sub => sub.TypeOfConsultationViewModel))
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

            #region PsychologistTypeOfConsultation

            config.CreateMap<CreatePsychologistTypeOfConsultation, PsychologistTypeOfConsultation>().ReverseMap();
            config.CreateMap<EditPsychologistTypeOfConsultation, PsychologistTypeOfConsultation>().ReverseMap();
            config.CreateMap<PsychologistTypeOfConsultationViewModel, PsychologistTypeOfConsultation>()
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ForMember(x => x.TypeOfConsultation, x => x.MapFrom(sub => sub.TypeOfConsultationViewModel))
                .ReverseMap();

            #endregion

            #region Articles

            config.CreateMap<CreateArticle, Article>().ReverseMap();
            config.CreateMap<EditArticle, Article>().ReverseMap();
            config.CreateMap<ArticleViewModel, Article>()
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
                .ReverseMap();

            #endregion

            #region PsychologistAboutUs

            config.CreateMap<CreatePsychologistAboutUs, PsychologistAboutUs>().ReverseMap();
            config.CreateMap<EditPsychologistAboutUs, PsychologistAboutUs>().ReverseMap();
            config.CreateMap<PsychologistAboutUsViewModel, PsychologistAboutUs>()
                .ForMember(x => x.Psychologist, x => x.MapFrom(sub => sub.PsychologistViewModel))
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