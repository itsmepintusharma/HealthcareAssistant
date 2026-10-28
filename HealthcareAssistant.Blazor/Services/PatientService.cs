using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class PatientService
{
    private readonly IHttpClientFactory _factory;

    public PatientService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Patient>> GetPatients()
    {
        var client = _factory.CreateClient("Api");

        var result =
            await client.GetFromJsonAsync<List<Patient>>
            ("api/patients");

        return result ?? new List<Patient>();
    }

    public async Task CreatePatient(Patient patient)
    {
        var client = _factory.CreateClient("Api");

        var response =
            await client.PostAsJsonAsync(
                "api/patients",
                patient);

        response.EnsureSuccessStatusCode();
    }
}