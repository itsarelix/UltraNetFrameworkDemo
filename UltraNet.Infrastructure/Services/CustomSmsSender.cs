using UltraNet.Framework.Core.Interfaces.Otp;

namespace UltraNet.Infrastructure.Services
{
    public class CustomSmsSender: IMessageSenderService
    {
        public Task SendAsync(string to, string message, string? subject = null)
        {
            Console.WriteLine($"[SMS] Sending to {to}: {message}");
            return Task.CompletedTask;
        }
    }
}
