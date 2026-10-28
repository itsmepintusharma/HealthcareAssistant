using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class AppointmentService
{
    private readonly IHttpClientFactory _factory;

    public AppointmentService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Appointment>> GetAppointments()
    {
        var client = _factory.CreateClient("Api");

        return await client.GetFromJsonAsync<List<Appointment>>
            ("api/appointments")
            ?? new();
    }

    public async Task CreateAppointment(
        Appointment appointment)
    {
        var client = _factory.CreateClient("Api");

        await client.PostAsJsonAsync(
            "api/appointments/book",
            appointment);
    }
}