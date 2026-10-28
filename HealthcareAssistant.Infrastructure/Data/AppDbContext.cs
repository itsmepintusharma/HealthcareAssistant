using HealthcareAssistant.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAssistant.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();

    public DbSet<PatientMemory> PatientMemories => Set<PatientMemory>();

    public DbSet<ConversationMemory> ConversationMemories => Set<ConversationMemory>();

    public DbSet<AgentExecutionLog> AgentExecutionLogs => Set<AgentExecutionLog>();

    public DbSet<ToolUsageLog> ToolUsageLogs => Set<ToolUsageLog>();

    public DbSet<EvaluationLog> EvaluationLogs => Set<EvaluationLog>();
}