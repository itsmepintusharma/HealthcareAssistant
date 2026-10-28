namespace HealthcareAssistant.Blazor.Models;

public class ConversationMemory
{
    public int Id { get; set; }

    public string SessionId { get; set; } = "";

    public string UserMessage { get; set; } = "";

    public string AgentResponse { get; set; } = "";
}