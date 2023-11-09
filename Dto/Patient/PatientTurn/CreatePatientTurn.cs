﻿using Utility.Dto;

namespace Dto.Patient.PatientTurn;

public class CreatePatientTurn : BaseDto
{
    public int PsychologistWorkingDateAndTimeId { get; set; }

    public int TypeOfConsultationId { get; set; }

    public int PatientId { get; set; }

    public DateTime ConsultationDay { get; set; }

    public int? Price { get; set; }
}