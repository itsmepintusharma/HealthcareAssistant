using HealthcareAssistant.Application.DTOs.Patient;
using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PatientsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _context.Patients.ToListAsync();

        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreatePatientDto dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Address = dto.Address,
            BloodGroup = dto.BloodGroup,
            EmergencyContact = dto.EmergencyContact
        };

        _context.Patients.Add(patient);

        await _context.SaveChangesAsync();

        return Ok(patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdatePatientDto dto)
    {
        var patient =
            await _context.Patients.FindAsync(id);

        if (patient == null)
            return NotFound();

        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.PhoneNumber = dto.PhoneNumber;
        patient.Address = dto.Address;
        patient.EmergencyContact = dto.EmergencyContact;

        await _context.SaveChangesAsync();

        return Ok(patient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var patient =
            await _context.Patients.FindAsync(id);

        if (patient == null)
            return NotFound();

        _context.Patients.Remove(patient);

        await _context.SaveChangesAsync();

        return Ok("Patient deleted.");
    }
}