using Microsoft.AspNetCore.Http;
using PC.Dto.Discount;
using PC.Dto.Order;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.User;
using PC.Utility.Dto;

namespace PC.Dto.Psychologist;

public class PsychologistViewModel : BaseDto
{
    public string NationalCode { get; set; }

    public string? MedicalLicennseCode { get; set; }

    public int Age { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Commission { get; set; }

    public IFormFile? ImageLicennse { get; set; }

    public string? EvidencePath { get; set; }

    public UserViewModel UserViewModel { get; set; }

    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimeViewModels { get; set; }

    public List<DiscountViewModel> DiscountViewModels { get; set; }

    public List<OrderViewModel> OrderViewModels { get; set; }

    public List<PsychologistTypeOfConsultationViewModel> PsychologistTypeOfConsultationViewModels { get; set; }
}