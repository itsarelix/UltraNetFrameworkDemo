using System.Security.Claims;
using UltraNet.Application.Common;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;
using UltraNet.Framework.Core.Interfaces.JWT;
using UltraNet.Framework.Core.Interfaces.PasswordHasher;

public class AuthService : IAuthService
{
    private static readonly Dictionary<string, string> _users = new();
    private readonly IPasswordHasher _hasher;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthService(IPasswordHasher hasher, ITokenGenerator tokenGenerator)
    {
        _hasher = hasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ReturnData<string>> Register(RegisterRequest request)
    {
        if (_users.ContainsKey(request.Username))
            return await Task.FromResult(ReturnData<string>.Fail("Username already exists."));

        var hashed = _hasher.HashPassword(request.Password);
        _users.Add(request.Username, hashed);

        return await Task.FromResult(ReturnData<string>.Success(_users.Last().Value, "User registered successfully."));
    }

    public async Task<ReturnData<TokenResponse>> Login(LoginRequest request)
    {
        if (!_users.TryGetValue(request.Username, out var hashed))
            return await Task.FromResult(ReturnData<TokenResponse>.Fail("User not found."));

        if (!_hasher.VerifyPassword(hashed, request.Password))
            return await Task.FromResult(ReturnData<TokenResponse>.Fail("Invalid credentials."));

        var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, request.Username),
          new Claim("CustomClaim", "ValueTest")
        };

        var token = _tokenGenerator.GenerateToken(claims);
        var refreshToken = _tokenGenerator.GenerateRefreshToken();

        var tokenResponse = new TokenResponse
        {
            token = token,
            refreshToken = refreshToken
        };

        return await Task.FromResult(ReturnData<TokenResponse>.Success(tokenResponse, "Login successful."));
    }
}