using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientMemoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public PatientMemoryController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _context.PatientMemories
                .ToListAsync());
    }
}