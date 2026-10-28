using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class MonitoringService
{
    private readonly IHttpClientFactory _factory;

    public MonitoringService(
        IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<AgentExecutionLog>>
        GetAgentLogsAsync()
    {
        var client =
            _factory.CreateClient("Api");

        return await client
            .GetFromJsonAsync<
                List<AgentExecutionLog>>
                ("api/monitoring/agents")
            ?? new();
    }

    public async Task<List<EvaluationLog>>
        GetEvaluationLogsAsync()
    {
        var client =
            _factory.CreateClient("Api");

        return await client
            .GetFromJsonAsync<
                List<EvaluationLog>>
                ("api/monitoring/evaluations")
            ?? new();
    }
}