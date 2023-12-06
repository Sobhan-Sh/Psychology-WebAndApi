﻿using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.Psychologist;

public class PsychologistTypeOfConsultation : BaseEntity
{
    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist Psychologist { get; set; }

    public int TypeOfConsultationId { get; set; }
    [ForeignKey("TypeOfConsultationId")]
    public TypeOfConsultation TypeOfConsultation { get; set; }
}