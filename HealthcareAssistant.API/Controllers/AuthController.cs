using BCrypt.Net;
using HealthcareAssistant.API.Authentication.DTOs;
using HealthcareAssistant.API.Authentication.Services;
using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(
        AppDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = request.Role,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    request.Password)
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return Ok("User registered.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request)
    {
        var user =
            await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Email == request.Email);

        if (user == null)
            return Unauthorized();

        var validPassword =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!validPassword)
            return Unauthorized();

        var token =
            _jwtService.GenerateToken(
                user.Id,
                user.Email,
                user.Role);

        return Ok(new LoginResponse
        {
            Token = token,
            Email = user.Email,
            Role = user.Role
        });
    }
}