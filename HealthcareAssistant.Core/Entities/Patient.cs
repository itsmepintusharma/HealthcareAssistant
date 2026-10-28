using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string BloodGroup { get; set; } = string.Empty;

    public string EmergencyContact { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public ICollection<Appointment>? Appointments { get; set; }

    public ICollection<MedicalRecord>? MedicalRecords { get; set; }
}
