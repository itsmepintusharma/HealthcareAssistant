using HealthcareAssistant.Agents.Models;
using HealthcareAssistant.Agents.Orchestrator;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly AgentOrchestrator _orchestrator;

    public AIController(
        AgentOrchestrator orchestrator)
    {
        _orchestrator = orchestrator;
    }

    [HttpPost("chat")]
    public async Task<IActionResult> Chat(
        AgentRequest request)
    {
        var result =
            await _orchestrator.ExecuteAsync(
                request.UserPrompt);

        return Ok(result);
    }
}