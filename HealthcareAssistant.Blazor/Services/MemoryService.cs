using System.Net.Http.Json;
using HealthcareAssistant.Blazor.Models;

namespace HealthcareAssistant.Blazor.Services;

public class MemoryService
{
    private readonly IHttpClientFactory _factory;

    public MemoryService(
        IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<ConversationMemory>>
        GetMemoriesAsync()
    {
        var client =
            _factory.CreateClient("Api");

        return await client
            .GetFromJsonAsync<
                List<ConversationMemory>>
                ("api/memoryviewer")
            ?? new();
    }
}