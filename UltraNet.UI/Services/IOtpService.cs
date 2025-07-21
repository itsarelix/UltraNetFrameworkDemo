using Microsoft.AspNetCore.Http;
using UltraNet.UI.Model;

namespace UltraNet.UI.Services
{
    public interface IOtpService
    {
        Task<ReturnData<string>?> SendOtpAsync(SendOtpRequest model);
        Task<ReturnData<string>?> VerifyOtpAsync(VerifyOtpRequest model);
    }
}
