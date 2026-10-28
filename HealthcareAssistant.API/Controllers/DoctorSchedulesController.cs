using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorSchedulesController : ControllerBase
{
    private readonly AppDbContext _context;

    public DoctorSchedulesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddSchedule(
        DoctorSchedule schedule)
    {
        _context.DoctorSchedules.Add(schedule);

        await _context.SaveChangesAsync();

        return Ok(schedule);
    }
}