﻿namespace PC.Dto.Patient.PatientTurn;

public class SearchPatientTurn
{
    public string? ConsultationDay { get; set; }

    public int? Price { get; set; }
    public bool? IsVisited { get; set; }

    public bool? IsCanseled { get; set; }
}