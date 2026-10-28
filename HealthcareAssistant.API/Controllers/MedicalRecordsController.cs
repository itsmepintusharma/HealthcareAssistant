using HealthcareAssistant.Application.DTOs.MedicalRecord;
using HealthcareAssistant.Core.Entities;
using HealthcareAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalRecordsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MedicalRecordsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMedicalRecordDto dto)
    {
        var record = new MedicalRecord
        {
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            Diagnosis = dto.Diagnosis,
            Prescription = dto.Prescription,
            Notes = dto.Notes
        };

        _context.MedicalRecords.Add(record);

        await _context.SaveChangesAsync();

        return Ok(record);
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetHistory(
        int patientId)
    {
        var records =
            await _context.MedicalRecords
            .Where(x => x.PatientId == patientId)
            .ToListAsync();

        return Ok(records);
    }
}