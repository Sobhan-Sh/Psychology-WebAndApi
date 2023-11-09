using Dto.Discount;
using Dto.Order;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Microsoft.AspNetCore.Http;
using Utility.Dto;

namespace Dto.Psychologist;

public class CreatePsychologist : BaseDto
{
    public string NationalCode { get; set; }

    public string? MedicalLicennseCode { get; set; }

    public int Age { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Commission { get; set; }

    public IFormFile? ImageLicennse { get; set; }

    public string? EvidencePath { get; set; }

    public int UserId { get; set; }

    public List<CreatePsychologistWorkingDateAndTime> PsychologistWorkingDateAndTime { get; set; }

    public List<CreateDiscount> Discount { get; set; }

    public List<CreateOrder> Order { get; set; }
}