using HealthcareAssistant.Application.DTOs.Appointment;
using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("book")]
    public async Task<IActionResult> Book(
        BookAppointmentDto dto)
    {
        var appointment = new Appointment
        {
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            AppointmentDate = dto.AppointmentDate,
            Reason = dto.Reason,
            Status = "Scheduled"
        };

        _context.Appointments.Add(appointment);

        await _context.SaveChangesAsync();

        return Ok(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .ToListAsync();

        return Ok(data);
    }
}