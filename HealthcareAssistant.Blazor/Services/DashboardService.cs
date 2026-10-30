using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class DashboardService
{
    private readonly IHttpClientFactory _factory;

    public DashboardService(
        IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<DashboardStats>
        GetStatsAsync()
    {
        var client =
            _factory.CreateClient("Api");

        return await client
            .GetFromJsonAsync<DashboardStats>(
                "api/dashboard")
            ?? new DashboardStats();
    }
}