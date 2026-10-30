using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HealthcareAssistant.Agents.AppointmentAgent;

public class AppointmentAgent
{
    private readonly AppDbContext _context;

    public AppointmentAgent(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExecuteAsync(
        string prompt)
    {
        // Patient Id

        var patientIdMatch =
            Regex.Match(
                prompt,
                @"patient\s+id\s+(\d+)",
                RegexOptions.IgnoreCase);

        if (!patientIdMatch.Success)
        {
            return "Patient Id not found in request.";
        }

        var patientId =
            int.Parse(
                patientIdMatch.Groups[1].Value);

        var doctors =
            await _context.Doctors.ToListAsync();

        Doctor? doctor = null;

        // 1. Doctor Id

        var doctorIdMatch =
            Regex.Match(
                prompt,
                @"doctor\s+id\s+(\d+)",
                RegexOptions.IgnoreCase);

        if (doctorIdMatch.Success)
        {
            var doctorId =
                int.Parse(
                    doctorIdMatch.Groups[1].Value);

            doctor =
                doctors.FirstOrDefault(x =>
                    x.Id == doctorId);
        }

        // 2. Doctor Name

        if (doctor == null)
        {
            doctor =
                doctors.FirstOrDefault(x =>
                    prompt.Contains(
                        x.DoctorName,
                        StringComparison.OrdinalIgnoreCase));
        }

        // 3. Specialization

        if (doctor == null)
        {
            var matchedDoctors =
                doctors.Where(x =>
                    prompt.Contains(
                        x.Specialization,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchedDoctors.Count == 1)
            {
                doctor = matchedDoctors.First();
            }
            else if (matchedDoctors.Count > 1)
            {
                return $"""
                            Multiple doctors found for specialization:

                            {string.Join(
                                Environment.NewLine,
                                matchedDoctors.Select(x =>
                                    $"{x.Id} - {x.DoctorName}"))}

                            Please specify doctor id or doctor name.
                            """;
            }
        }

        // Not found

        if (doctor == null)
        {
            return """
                        No matching doctor found.

                        Please specify:

                        - Doctor Id
                        OR
                        - Doctor Name
                        OR
                        - Doctor Specialization
                        """;
        }

        var appointmentDate =
            GetAppointmentDate(prompt);

        var appointment =
            new Appointment
            {
                PatientId = patientId,

                DoctorId = doctor.Id,

                AppointmentDate =
                    appointmentDate,

                Status = "Scheduled",

                Reason = "AI Generated"
            };

        _context.Appointments.Add(
            appointment);

        await _context.SaveChangesAsync();

        return $"""
                    Appointment booked successfully.

                    Patient Id: {patientId}

                    Doctor: {doctor.DoctorName}

                    Specialization:
                    {doctor.Specialization}

                    Date:
                    {appointmentDate:dd-MMM-yyyy}

                    Appointment Id:
                    {appointment.Id}
                    """;
    }

    private DateTime GetAppointmentDate(
        string prompt)
    {
        if (prompt.Contains(
                "tomorrow",
                StringComparison.OrdinalIgnoreCase))
        {
            return DateTime.Today.AddDays(1);
        }

        if (prompt.Contains(
                "next week",
                StringComparison.OrdinalIgnoreCase))
        {
            return DateTime.Today.AddDays(7);
        }

        var dateMatch =
            Regex.Match(
                prompt,
                @"\b(\d{2}[/-]\d{2}[/-]\d{4})\b");

        if (dateMatch.Success)
        {
            if (DateTime.TryParse(
                    dateMatch.Value,
                    out var parsedDate))
            {
                return parsedDate;
            }
        }

        return DateTime.Today;
    }
}