using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
