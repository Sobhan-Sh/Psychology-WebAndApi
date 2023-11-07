using AutoMapper;
using Dto.account;
using Dto.Patient;
using Dto.Patient.PatientFile;
using Dto.Patient.Timing;
using Dto.Role;
using Dto.Test;
using Dto.Test.Answer;
using Dto.Test.Question;
using Dto.User;
using Entity.Patient;
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

            #endregion

            #region User

            config.CreateMap<CreateUser, User>().ReverseMap();

            config.CreateMap<UserViewModel, User>()
                .ForMember(x => x.Role, x => x.MapFrom(sub => sub.RoleViewModel)).ReverseMap();

            config.CreateMap<EditUser, User>().ReverseMap();


            #endregion
        });

        return mappingConfig;
    }
}