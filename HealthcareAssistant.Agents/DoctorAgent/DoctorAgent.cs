using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HealthcareAssistant.Agents.DoctorAgent;

public class DoctorAgent
{
    private readonly AppDbContext _context;

    public DoctorAgent(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExecuteAsync(
        string prompt)
    {
        var doctors =
            await _context.Doctors.ToListAsync();

        var doctor =
            doctors.FirstOrDefault(x =>
                prompt.Contains(
                    x.DoctorName,
                    StringComparison.OrdinalIgnoreCase));

        if (doctor == null)
        {
            return "Doctor not found.";
        }

        var sb = new StringBuilder();

        sb.AppendLine(
            $"Doctor Id : {doctor.Id}");

        sb.AppendLine(
            $"Doctor Name : {doctor.DoctorName}");

        sb.AppendLine(
            $"Specialization : {doctor.Specialization}");

        return sb.ToString();
    }
}