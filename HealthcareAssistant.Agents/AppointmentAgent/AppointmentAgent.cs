using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.Agents.AppointmentAgent;

public class AppointmentAgent
{
    private readonly AppDbContext _context;

    public AppointmentAgent(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExecuteAsync()
    {
        var count =
            await _context.Appointments.CountAsync();

        return $"Total appointments: {count}";
    }
}