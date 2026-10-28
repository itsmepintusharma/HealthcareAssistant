namespace HealthcareAssistant.Blazor.Models;

public class Doctor
{
    public int Id { get; set; }

    public string DoctorName { get; set; } = "";

    public string Specialization { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string LicenseNumber { get; set; } = "";
}