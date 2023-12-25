using PC.Utility.Dto;

namespace PC.Dto.Psychologist.PsychologistAboutUs;

public class PsychologistAboutUsViewModel : BaseDto
{
    public string Title { get; set; }

    public string TextAbout { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }
}