using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = new
        {
            Patients =
                await _context.Patients.CountAsync(),

            Doctors =
                await _context.Doctors.CountAsync(),

            Appointments =
                await _context.Appointments.CountAsync(),

            Conversations =
                await _context.ConversationMemories
                    .CountAsync()
        };

        return Ok(result);
    }
}