namespace ParkBuddy.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid id, string email, string role);
    }
}