using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class AuthService
{
    private readonly IHttpClientFactory _factory;

    public AuthService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<bool> Login(LoginRequest request)
    {
        var client = _factory.CreateClient("Api");

        var response =
            await client.PostAsJsonAsync(
                "api/auth/login",
                request);

        return response.IsSuccessStatusCode;
    }
}