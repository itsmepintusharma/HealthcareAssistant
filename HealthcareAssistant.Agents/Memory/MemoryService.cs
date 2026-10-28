using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.Agents.Memory;

public class MemoryService : IMemoryService
{
    private readonly AppDbContext _context;

    public MemoryService(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveConversationAsync(
        string sessionId,
        string userMessage,
        string response)
    {
        var memory = new ConversationMemory
        {
            SessionId = sessionId,
            UserMessage = userMessage,
            AgentResponse = response
        };

        _context.ConversationMemories.Add(memory);

        await _context.SaveChangesAsync();
    }

    public async Task SavePatientMemoryAsync(
        int patientId,
        string memoryText)
    {
        var memory = new PatientMemory
        {
            PatientId = patientId,
            MemoryText = memoryText
        };

        _context.PatientMemories.Add(memory);

        await _context.SaveChangesAsync();
    }

    public async Task<List<string>>
        GetPatientMemoryAsync(int patientId)
    {
        return await _context.PatientMemories
            .Where(x => x.PatientId == patientId)
            .Select(x => x.MemoryText)
            .ToListAsync();
    }
}
