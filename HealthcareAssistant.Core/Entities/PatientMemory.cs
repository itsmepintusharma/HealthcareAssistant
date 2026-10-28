using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class PatientMemory
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string MemoryText { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
