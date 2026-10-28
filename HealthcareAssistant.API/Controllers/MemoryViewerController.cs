using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemoryViewerController : ControllerBase
{
    private readonly AppDbContext _context;

    public MemoryViewerController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _context.ConversationMemories
                .OrderByDescending(x => x.Id)
                .ToListAsync());
    }
}