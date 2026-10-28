using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAssistant.Agents.Models;

namespace HealthcareAssistant.Agents.PlannerAgent
{

    public interface IPlannerAgent
    {
        Task<PlanResult> CreatePlanAsync(
            string userPrompt);
    }
}
