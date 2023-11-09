﻿using Dto.Patient.PatientFile;
using Dto.User;
using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Patient;

public class CreatePatient : BaseDto
{
    [Required]
    public string NationalCode { get; set; }

    [Required]
    public int Age { get; set; }

    public int UserId { get; set; }

    public int PatientExamId { get; set; }

    public int TimingId { get; set; }
}