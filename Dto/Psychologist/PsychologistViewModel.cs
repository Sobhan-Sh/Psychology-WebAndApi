using Dto.Discount;
using Dto.Order;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.User;
using Microsoft.AspNetCore.Http;
using Utility.Dto;

namespace Dto.Psychologist;

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
}