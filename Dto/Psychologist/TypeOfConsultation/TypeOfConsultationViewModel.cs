﻿using Dto.Patient.PatientTurn;

namespace Dto.Psychologist.TypeOfConsultation;

public class TypeOfConsultationViewModel : CreateTypeOfConsultation
{
    public List<PatientTurnViewModel> PatientTurnViewModels { get; set; }
}