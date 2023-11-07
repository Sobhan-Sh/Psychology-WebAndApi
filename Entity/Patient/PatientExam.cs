using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Patient;

public class PatientExam
{
    [Required]
    public int Id { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    public int TestId { get; set; }
    [ForeignKey("TestId")]
    public Test.Test Test { get; set; }

    public List<PatientResponses> PatientResponses { get; set; }
}