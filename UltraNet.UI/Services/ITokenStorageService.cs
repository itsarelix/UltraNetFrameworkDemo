namespace UltraNet.UI.Services
{
    public interface ITokenStorageService
    { 
        void SetToken(string token);
        Task<string?> GetToken();
        void ClearToken();
    }
}
