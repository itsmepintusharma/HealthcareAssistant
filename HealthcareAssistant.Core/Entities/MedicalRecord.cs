using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class MedicalRecord
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Prescription { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public DateTime RecordDate { get; set; } = DateTime.UtcNow;

    public Patient? Patient { get; set; }

    public Doctor? Doctor { get; set; }
}