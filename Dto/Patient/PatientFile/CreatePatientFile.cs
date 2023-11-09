﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Patient.PatientFile;

public class CreatePatientFile : BaseDto
{
    [Required]
    public IFormFile File { get; set; }

    public string? FilePath { get; set; }

    [Required]
    public int PatientId { get; set; }
}