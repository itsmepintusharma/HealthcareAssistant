using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class DoctorService
{
    private readonly IHttpClientFactory _factory;

    public DoctorService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        var client = _factory.CreateClient("Api");

        return await client.GetFromJsonAsync<List<Doctor>>
            ("api/doctors")
            ?? new();
    }

    public async Task CreateDoctor(Doctor doctor)
    {
        var client = _factory.CreateClient("Api");

        var response =
            await client.PostAsJsonAsync(
                "api/doctors",
                doctor);

        response.EnsureSuccessStatusCode();
    }
}