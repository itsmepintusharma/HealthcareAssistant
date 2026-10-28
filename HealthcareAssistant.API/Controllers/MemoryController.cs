using HealthcareAssistant.Agents.Memory;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemoryController : ControllerBase
{
    private readonly IMemoryService _memory;

    public MemoryController(
        IMemoryService memory)
    {
        _memory = memory;
    }

    [HttpPost("patient")]
    public async Task<IActionResult> SavePatientMemory(
        int patientId,
        string text)
    {
        await _memory.SavePatientMemoryAsync(
            patientId,
            text);

        return Ok();
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientMemory(
        int patientId)
    {
        var result =
            await _memory.GetPatientMemoryAsync(
                patientId);

        return Ok(result);
    }
}