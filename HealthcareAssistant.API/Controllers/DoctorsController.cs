using HealthcareAssistant.Application.DTOs.Doctor;
using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class DoctorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DoctorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Doctors.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateDoctorDto dto)
    {
        var doctor = new Doctor
        {
            DoctorName = dto.DoctorName,
            Specialization = dto.Specialization,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            LicenseNumber = dto.LicenseNumber,
            IsAvailable = true
        };

        _context.Doctors.Add(doctor);

        await _context.SaveChangesAsync();

        return Ok(doctor);
    }
}