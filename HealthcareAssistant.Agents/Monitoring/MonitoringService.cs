using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;

namespace HealthcareAssistant.Agents.Monitoring;

public class MonitoringService : IMonitoringService
{
    private readonly AppDbContext _context;

    public MonitoringService(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task LogAgentAsync(
        string agentName,
        string taskName,
        string result)
    {
        var log = new AgentExecutionLog
        {
            AgentName = agentName,
            TaskName = taskName,
            Success = true,
            Result = result
        };

        _context.AgentExecutionLogs.Add(log);

        await _context.SaveChangesAsync();
    }

    public async Task LogToolAsync(
        string toolName,
        bool success,
        string response)
    {
        var log = new ToolUsageLog
        {
            ToolName = toolName,
            Success = success,
            Response = response
        };

        _context.ToolUsageLogs.Add(log);

        await _context.SaveChangesAsync();
    }
}