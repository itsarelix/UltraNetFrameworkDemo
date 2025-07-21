
namespace UltraNet.UI.Services
{
    public class TokenStorageService : ITokenStorageService
    {
        private string? _token;

        public void SetToken(string token)
        {
            _token = token;
        }


        public void ClearToken()
        {
            _token = null;
        }

        public async Task<string?> GetToken()
        {
            return _token;

        }
    }

}
