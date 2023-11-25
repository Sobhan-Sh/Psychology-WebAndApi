using System.ComponentModel.DataAnnotations;
using Dto.Test;
using Dto.Test.Answer;
using Dto.Test.Question;

namespace Dto.Patient.PatientResponsesExams;

public class CreatePatientResponsesExams
{
    [Required] public CreateTest CreateTest { get; set; }

    [Required] public List<CreateQuestion> CreateQuestions { get; set; }

    [Required] public List<CreateAnswer> CreateAnswers { get; set; }

    public int? Score { get; set; }

    public string? Title { get; set; }

    public string? PathFile { get; set; }

    public int? PatientId { get; set; }

    public int? TestId { get; set; }

    public int? PatientExamId { get; set; }
}