namespace UltraNet.Framework.Core.Interfaces.Otp
{
    public interface IOTPService
    {
        Task<string> GenerateAndSendOtpAsync(string receiver, int? length = null);
        Task<bool> VerifyOtpAsync(string receiver, string inputCode);

    }
}
