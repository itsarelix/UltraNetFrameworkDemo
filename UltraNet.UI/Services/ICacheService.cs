using Microsoft.AspNetCore.Http;
using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public interface ICacheService
    {
        Task<ReturnData<string>?> CacheData(CacheRequest cacheRequest);
    }
}
