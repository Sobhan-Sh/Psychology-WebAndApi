using System.ComponentModel.DataAnnotations;
using PC.Dto.Test;
using PC.Dto.Test.Answer;
using PC.Dto.Test.Question;

namespace PC.Dto.Patient.PatientResponsesExams;

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