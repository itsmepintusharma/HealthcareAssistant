using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Agents.Monitoring;

public interface IMonitoringService
{
    Task LogAgentAsync(
        string agentName,
        string taskName,
        string result);

    Task LogToolAsync(
        string toolName,
        bool success,
        string response);
}
