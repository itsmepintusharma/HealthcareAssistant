namespace HealthcareAssistant.API.Authentication.Services;

public interface IJwtService
{
    string GenerateToken(
        int userId,
        string email,
        string role);
}