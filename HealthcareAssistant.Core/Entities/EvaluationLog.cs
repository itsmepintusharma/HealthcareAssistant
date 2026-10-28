using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class EvaluationLog
{
    public int Id { get; set; }

    public string Query { get; set; } = string.Empty;

    public string Response { get; set; } = string.Empty;

    public double RelevanceScore { get; set; }

    public double AccuracyScore { get; set; }

    public DateTime EvaluatedAt { get; set; } = DateTime.UtcNow;
}