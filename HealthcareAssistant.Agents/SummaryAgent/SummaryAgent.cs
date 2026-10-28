using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Agents.SummaryAgent;

public class SummaryAgent
{
    public async Task<string> ExecuteAsync(
        List<string> previousResults)
    {
        return await Task.FromResult(
            string.Join(
                Environment.NewLine,
                previousResults));
    }
}
