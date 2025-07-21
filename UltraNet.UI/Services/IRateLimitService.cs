using Microsoft.AspNetCore.Http;
using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public interface IRateLimitService
    {
        Task<ReturnData<string>?> CheckRateLimit(RateLimitRequest model);
    }
}
