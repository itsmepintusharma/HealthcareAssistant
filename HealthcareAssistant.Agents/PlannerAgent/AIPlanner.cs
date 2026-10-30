using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace HealthcareAssistant.Agents.PlannerAgent;

public class AIPlanner : IAIPlanner
{
    private readonly Kernel _kernel;

    public AIPlanner(IConfiguration configuration)
    {
        var builder = Kernel.CreateBuilder();

        builder.AddOpenAIChatCompletion(
            modelId: configuration["OpenAI:Model"]!,
            apiKey: configuration["OpenAI:ApiKey"]!);

        _kernel = builder.Build();
    }

    public async Task<List<string>> GeneratePlanAsync(
        string userPrompt)
    {
        var prompt =
        """
        You are a Healthcare Planner Agent.

        Analyze the user request and select the most appropriate
        tasks from the list below.

        Available Tasks:

        GET_HISTORY
        BOOK_APPOINTMENT
        SEARCH_DISEASE
        GET_DOCTOR
        GET_PATIENT
        GENERATE_SUMMARY

        Rules:
        - Return only task names.
        - One task per line.
        - Do not return explanations.
        - Do not return numbering.

        User Request:
        {{$input}}
        """;

        var result =
            await _kernel.InvokePromptAsync(
                prompt,
                new()
                {
                    ["input"] = userPrompt
                });

        return result.ToString()!
            .Split(
                '\n',
                StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList();
    }
}