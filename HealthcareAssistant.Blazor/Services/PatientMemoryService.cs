using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class PatientMemoryService
{
    private readonly IHttpClientFactory _factory;

    public PatientMemoryService(
        IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<PatientMemory>>
        GetMemoriesAsync()
    {
        var client =
            _factory.CreateClient("Api");

        return await client
            .GetFromJsonAsync<
                List<PatientMemory>>
                ("api/patientmemory")
            ?? new();
    }
}