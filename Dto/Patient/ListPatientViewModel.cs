using PC.Dto.Psychologist;

namespace PC.Dto.Patient;

public class ListPatientViewModel
{
    public int PatientId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public string Phone { get; set; }

    public bool MobailActiveStatus { get; set; }

    public string NationalCode { get; set; }

    public List<PsychologistViewModel> PsychologistViewModels { get; set; }
}