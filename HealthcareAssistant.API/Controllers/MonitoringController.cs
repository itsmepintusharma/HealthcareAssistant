using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonitoringController : ControllerBase
{
    private readonly AppDbContext _context;

    public MonitoringController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("agents")]
    public async Task<IActionResult> Agents()
    {
        return Ok(
            await _context.AgentExecutionLogs
                .OrderByDescending(x => x.Id)
                .ToListAsync());
    }

    [HttpGet("tools")]
    public async Task<IActionResult> Tools()
    {
        return Ok(
            await _context.ToolUsageLogs
                .OrderByDescending(x => x.Id)
                .ToListAsync());
    }

    [HttpGet("evaluations")]
    public async Task<IActionResult> Evaluations()
    {
        return Ok(
            await _context.EvaluationLogs
                .OrderByDescending(x => x.Id)
                .ToListAsync());
    }
}