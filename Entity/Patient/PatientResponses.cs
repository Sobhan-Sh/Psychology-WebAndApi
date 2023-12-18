using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;

namespace PD.Entity.Patient;

public class PatientResponses : BaseEntity
{
    public int PatientExamId { get; set; }
    [ForeignKey("PatientExamId")]
    public PatientExam PatientExam { get; set; }

    public int Score { get; set; }

    public string PathFile { get; set; }
}