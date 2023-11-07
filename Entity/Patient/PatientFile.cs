using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.Patient;

public class PatientFile : BaseEntity
{
    public string FilePath { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    public void Active()
    {
        IsActive = true;
    }

    public void DeActive()
    {
        IsActive = false;
    }
}