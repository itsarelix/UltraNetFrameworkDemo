namespace UltraNet.Framework.Core.Interfaces.Otp
{
    public interface IMessageSenderService
    {
        Task SendAsync(string to, string message, string? subject = null);
    }
}
