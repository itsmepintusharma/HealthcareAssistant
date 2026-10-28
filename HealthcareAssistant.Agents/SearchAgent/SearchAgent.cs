using HealthcareAssistant.RAG.Retrieval;

namespace HealthcareAssistant.Agents.SearchAgent;

public class SearchAgent
{
    private readonly IRagService _ragService;

    public SearchAgent(
        IRagService ragService)
    {
        _ragService = ragService;
    }

    public async Task<string>
        ExecuteAsync(string query)
    {
        return await _ragService
            .SearchAsync(query);
    }
}