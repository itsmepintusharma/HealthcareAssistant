using HealthcareAssistant.Agents.AppointmentAgent;
using HealthcareAssistant.Agents.MedicalRecordAgent;
using HealthcareAssistant.Agents.Memory;
using HealthcareAssistant.Agents.Monitoring;
using HealthcareAssistant.Agents.PlannerAgent;
using HealthcareAssistant.Agents.SearchAgent;
using HealthcareAssistant.Agents.SummaryAgent;

namespace HealthcareAssistant.Agents.Orchestrator;

public class AgentOrchestrator
{
    private readonly IPlannerAgent _planner;

    private readonly AppointmentAgent.AppointmentAgent _appointmentAgent;

    private readonly MedicalRecordAgent.MedicalRecordAgent _recordAgent;

    private readonly SearchAgent.SearchAgent _searchAgent;

    private readonly SummaryAgent.SummaryAgent _summaryAgent;

    private readonly IMemoryService _memoryService;
    private readonly IMonitoringService _monitoring;
    private readonly EvaluationService _evaluationService;

    public AgentOrchestrator(
        IPlannerAgent planner,
        AppointmentAgent.AppointmentAgent appointmentAgent,
        MedicalRecordAgent.MedicalRecordAgent recordAgent,
        SearchAgent.SearchAgent searchAgent,
        SummaryAgent.SummaryAgent summaryAgent,
        IMemoryService memoryService,
        IMonitoringService monitoring,
        EvaluationService evaluationService)
    {
        _planner = planner;
        _appointmentAgent = appointmentAgent;
        _recordAgent = recordAgent;
        _searchAgent = searchAgent;
        _summaryAgent = summaryAgent;
        _memoryService = memoryService;
        _monitoring = monitoring;
        _evaluationService = evaluationService;
    }

    public async Task<string> ExecuteAsync(
        string prompt)
    {
        var results = new List<string>();

        // STEP 9 - Read Patient Memory
        var memories =
            await _memoryService
                .GetPatientMemoryAsync(1);

        if (memories.Any())
        {
            results.Add(
                $"Patient Memory: {string.Join(", ", memories)}");
        }

        // Create Plan
        var plan =
            await _planner.CreatePlanAsync(prompt);

        // Execute Agents
        foreach (var task in plan.Tasks)
        {
            switch (task)
            {
                case "BOOK_APPOINTMENT":

                    var appointmentResult =
                        await _appointmentAgent.ExecuteAsync();

                    await _monitoring.LogAgentAsync(
                        "AppointmentAgent",
                        task,
                        appointmentResult);

                    results.Add(appointmentResult);

                    break;

                case "GET_HISTORY":

                    var historyResult =
                        await _recordAgent.ExecuteAsync();

                    await _monitoring.LogAgentAsync(
                        "MedicalRecordAgent",
                        task,
                        historyResult);

                    results.Add(historyResult);

                    break;

                case "SEARCH_DISEASE":

                    var searchResult =
                        await _searchAgent.ExecuteAsync(prompt);

                    await _monitoring.LogAgentAsync(
                        "SearchAgent",
                        task,
                        searchResult);

                    results.Add(searchResult);

                    break;
            }
        }

        // Generate Summary
        var finalResponse =
            await _summaryAgent.ExecuteAsync(results);

        // Save Conversation Memory
        Console.WriteLine("Saving conversation...");
        await _memoryService
            .SaveConversationAsync(
                Guid.NewGuid().ToString(),
                prompt,
                finalResponse);

        await _evaluationService
        .SaveEvaluationAsync(
        prompt,
        finalResponse);

        return finalResponse;
    }
}