using System.Text;
using HealthcareAssistant.Agents.AppointmentAgent;
using HealthcareAssistant.Agents.MedicalRecordAgent;
using HealthcareAssistant.Agents.Memory;
using HealthcareAssistant.Agents.Monitoring;
using HealthcareAssistant.Agents.Orchestrator;
using HealthcareAssistant.Agents.PlannerAgent;
using HealthcareAssistant.Agents.SearchAgent;
using HealthcareAssistant.Agents.SummaryAgent;
using HealthcareAssistant.API.Authentication.Services;
using HealthcareAssistant.Application.Common;
using HealthcareAssistant.Infrastructure.Data;
using HealthcareAssistant.RAG.Retrieval;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Service
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IPlannerAgent, PlannerAgent>();
builder.Services.AddScoped<AppointmentAgent>();
builder.Services.AddScoped<MedicalRecordAgent>();
builder.Services.AddScoped<SearchAgent>();
builder.Services.AddScoped<SummaryAgent>();
builder.Services.AddScoped<IMemoryService, MemoryService>();
builder.Services.AddScoped<IRagService, RagService>();
builder.Services.AddScoped<IAIPlanner, AIPlanner>();
builder.Services.AddScoped<IMonitoringService,MonitoringService>();
builder.Services.AddScoped<EvaluationService>();
builder.Services.Configure<OpenAISettings>(
    builder.Configuration.GetSection("OpenAI"));


builder.Services.AddScoped<AgentOrchestrator>();

// Authentication
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });

// Authorization
builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Healthcare Assistant API",
            Version = "v1"
        });

    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter JWT Token"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference =
                        new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazor");

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();