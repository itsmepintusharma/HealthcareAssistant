using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class AgentExecutionLog
{
    public int Id { get; set; }

    public string AgentName { get; set; } = string.Empty;

    public string TaskName { get; set; } = string.Empty;

    public bool Success { get; set; }

    public string Result { get; set; } = string.Empty;

    public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
}
