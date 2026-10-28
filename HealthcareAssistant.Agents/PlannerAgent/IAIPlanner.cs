using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Agents.PlannerAgent;

public interface IAIPlanner
{
    Task<List<string>> GeneratePlanAsync(
        string userPrompt);
}
