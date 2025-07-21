
namespace UltraNet.Application.Models
{
    public class VerifyOtpRequest
    {
        public string Receiver { get; set; } = string.Empty;
        public string InputCode { get; set; } = string.Empty;

    }
}

