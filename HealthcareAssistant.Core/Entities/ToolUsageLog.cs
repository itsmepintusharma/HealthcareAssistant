using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class ToolUsageLog
{
    public int Id { get; set; }

    public string ToolName { get; set; } = string.Empty;

    public bool Success { get; set; }

    public string Response { get; set; } = string.Empty;

    public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
}
