namespace HealthcareAssistant.Blazor.Models;

public class EvaluationLog
{
    public int Id { get; set; }

    public string Query { get; set; } = "";

    public string Response { get; set; } = "";

    public double RelevanceScore { get; set; }

    public double AccuracyScore { get; set; }
}