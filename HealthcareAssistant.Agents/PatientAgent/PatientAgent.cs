using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HealthcareAssistant.Agents.PatientAgent;

public class PatientAgent
{
    private readonly AppDbContext _context;

    public PatientAgent(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExecuteAsync(
        string prompt)
    {
        var match =
            Regex.Match(
                prompt,
                @"patient\s+id\s+(\d+)",
                RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            return "Patient Id not found.";
        }

        var patientId =
            int.Parse(match.Groups[1].Value);

        var patient =
            await _context.Patients
                .FirstOrDefaultAsync(x =>
                    x.Id == patientId);

        if (patient == null)
        {
            return "Patient not found.";
        }

        return $"""
Patient Id : {patient.Id}

Patient Name : {patient.FirstName} {patient.LastName}

Age : {patient.DateOfBirth}

Gender : {patient.Gender}
""";
    }
}