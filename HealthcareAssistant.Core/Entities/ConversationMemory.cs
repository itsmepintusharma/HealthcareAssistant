using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class ConversationMemory
{
    public int Id { get; set; }

    public string SessionId { get; set; } = string.Empty;

    public string UserMessage { get; set; } = string.Empty;

    public string AgentResponse { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
