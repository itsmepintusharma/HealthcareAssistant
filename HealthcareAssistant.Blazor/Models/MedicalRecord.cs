namespace HealthcareAssistant.Blazor.Models;

public class MedicalRecord
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = "";

    public string Prescription { get; set; } = "";

    public string Notes { get; set; } = "";
}