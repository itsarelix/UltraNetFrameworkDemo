using System.Security.Claims;

namespace UltraNet.Framework.Core.Interfaces.JWT
{
    public interface ITokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
