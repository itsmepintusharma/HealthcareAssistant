namespace HealthcareAssistant.Blazor.Models;

public class PatientMemory
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string MemoryText { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}