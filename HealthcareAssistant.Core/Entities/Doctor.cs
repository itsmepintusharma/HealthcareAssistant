using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class Doctor
{
    public int Id { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public string Specialization { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string LicenseNumber { get; set; } = string.Empty;

    public bool IsAvailable { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }
}
