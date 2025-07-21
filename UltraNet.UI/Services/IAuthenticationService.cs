using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public interface IAuthenticationService
    {
        Task<ReturnData<string>?> RegisterAsync(RegisterRequest model);
        Task<ReturnData<TokenResponse>?> LoginAsync(LoginRequest model);
    }
}
