using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class AIService
{
    private readonly IHttpClientFactory _factory;

    public AIService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string> ChatAsync(string prompt)
    {
        var client = _factory.CreateClient("Api");

        var request = new AIRequest
        {
            UserPrompt = prompt
        };

        var response =
            await client.PostAsJsonAsync(
                "api/ai/chat",
                request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}