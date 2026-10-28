using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Agents.Memory;

public interface IMemoryService
{
    Task SaveConversationAsync(
        string sessionId,
        string userMessage,
        string response);

    Task SavePatientMemoryAsync(
        int patientId,
        string memory);

    Task<List<string>> GetPatientMemoryAsync(
        int patientId);
}
