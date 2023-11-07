using AutoMapper;
using Dto.Patient.PatientResponsesExams;
using Entity.Patient;
using Service.IRepository.Patient;
using Service.IService.Patient;
using System.Text.Json;
using Utility.ReturnFuncResult;
using Utility.UploadFileTools;
using Utility.Validation;
using static Service.Mapping.Mapping;

namespace Service.Service.Patient;

public class PatientResponsesExamsService : IPatientResponsesExamsService
{
    private readonly IPatientResponsRepository _patientResponsRepository;
    private readonly IPatientExamRepository _examRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientResponsesExamsService(IPatientResponsRepository patientResponsRepository, IPatientExamRepository examRepository, IPatientRepository patientRepository, IMapper mapper)
    {
        _patientResponsRepository = patientResponsRepository;
        _examRepository = examRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult> CreateAsync(CreatePatientResponsesExams command)
    {
        try
        {
            if (command == null)
                return new BaseResult()
                {
                    StatusCode = ValidationCode.BadRequest,
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired
                };


            foreach (var s in command.CreateAnswers)
            {
                command.Score += s.Score;
            }

            PatientResponsesExams_Test data = new PatientResponsesExams_Test();
            data.CreatedAt = DateTime.Now.ToString();
            data.Title = command.Title;
            data.Id = (int)command.TestId;
            data.IsActive = true;
            foreach (var q in command.CreateQuestions)
            {
                var answer = command.CreateAnswers.FirstOrDefault(x => x.QuestionId == q.Id);
                data.Questions.Add(new()
                {
                    TestId = (int)command.TestId,
                    Answer = new PatientResponsesExams_Answer()
                    {
                        QuestionId = q.Id,
                        Description = answer.Description,
                        Score = answer.Score,
                        Title = answer.Title
                    }
                });
            }

            // convert model to json
            var fileName = Guid.NewGuid().ToString("N") + ".jsone";
            // query get user
            var patient = await _patientRepository.GetAsync(x => x.Id == command.PatientId, "Users");
            // create path
            string pathFilePatient = PathExtention.PatientFile + "/" + patient.User.FullName();
            // query get user
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText($"{pathFilePatient}.json", json);
            command.PathFile = fileName;

            // save data
            PatientExam patientExam = PatientExamMapping(command);
            await _examRepository.CreateAsync(patientExam);
            await _examRepository.SaveAsync();
            command.PatientExamId = patientExam.Id;
            PatientResponses patientResponses = PatientResponsesMapping(command);
            await _patientResponsRepository.CreateAsync(patientResponses);
            await _examRepository.SaveAsync();
            return new BaseResult()
            {
                StatusCode = ValidationCode.Success,
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreate
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                StatusCode = ValidationCode.BadRequest,
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message)
            };
        }
    }
}