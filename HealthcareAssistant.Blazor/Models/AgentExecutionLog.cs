namespace HealthcareAssistant.Blazor.Models;

public class AgentExecutionLog
{
    public int Id { get; set; }

    public string AgentName { get; set; } = "";

    public string TaskName { get; set; } = "";

    public bool Success { get; set; }

    public string Result { get; set; } = "";
}