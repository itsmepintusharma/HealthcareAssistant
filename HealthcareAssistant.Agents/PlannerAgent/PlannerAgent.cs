using HealthcareAssistant.Agents.Models;

namespace HealthcareAssistant.Agents.PlannerAgent;

public class PlannerAgent : IPlannerAgent
{
    private readonly IAIPlanner _aiPlanner;

    public PlannerAgent(
        IAIPlanner aiPlanner)
    {
        _aiPlanner = aiPlanner;
    }

    public async Task<PlanResult>
        CreatePlanAsync(string userPrompt)
    {
        var tasks =
            await _aiPlanner
                .GeneratePlanAsync(userPrompt);

        return new PlanResult
        {
            Tasks = tasks
        };
    }
}