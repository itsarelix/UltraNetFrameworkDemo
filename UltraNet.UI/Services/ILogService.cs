using Microsoft.AspNetCore.Http;
using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public interface ILogService
    {
        Task<ReturnData<string>?> LogDataAsync();    }
}
