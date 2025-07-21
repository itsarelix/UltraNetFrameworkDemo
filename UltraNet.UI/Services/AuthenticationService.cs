using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _http;
        private readonly ITokenStorageService _tokenStorage;

        public AuthenticationService(IHttpClientFactory factory, ITokenStorageService tokenStorage)
        {
            _http = factory.CreateClient("PublicClient");
            _tokenStorage = tokenStorage;
        }

        public async Task<ReturnData<string>?> RegisterAsync(RegisterRequest model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", model);
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<ReturnData<string>>();
            return result;
        }

        public async Task<ReturnData<TokenResponse>?> LoginAsync(LoginRequest model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", model);
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<ReturnData<TokenResponse>>();

            if (result?.Data?.token is not null)
            {
                 _tokenStorage.SetToken(result.Data.token);
            }

            return result;
        }

        public async Task LogoutAsync()
        {
             _tokenStorage.ClearToken();
        }
    }
}