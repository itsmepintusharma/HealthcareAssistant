using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class MedicalRecordService
{
    private readonly IHttpClientFactory _factory;

    public MedicalRecordService(
        IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task CreateRecord(
        MedicalRecord record)
    {
        var client = _factory.CreateClient("Api");

        await client.PostAsJsonAsync(
            "api/medicalrecords",
            record);
    }
}