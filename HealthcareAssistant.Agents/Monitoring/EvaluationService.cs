using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;

namespace HealthcareAssistant.Agents.Monitoring;

public class EvaluationService
{
    private readonly AppDbContext _context;

    public EvaluationService(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveEvaluationAsync(
        string query,
        string response)
    {
        var evaluation = new EvaluationLog
        {
            Query = query,
            Response = response,
            RelevanceScore = 0.95,
            AccuracyScore = 0.95
        };

        _context.EvaluationLogs.Add(evaluation);

        await _context.SaveChangesAsync();
    }
}