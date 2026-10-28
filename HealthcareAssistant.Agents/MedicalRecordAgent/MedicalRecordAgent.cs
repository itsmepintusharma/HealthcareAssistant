using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.Agents.MedicalRecordAgent;

public class MedicalRecordAgent
{
    private readonly AppDbContext _context;

    public MedicalRecordAgent(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExecuteAsync()
    {
        var count =
            await _context.MedicalRecords.CountAsync();

        return $"Medical records found: {count}";
    }
}