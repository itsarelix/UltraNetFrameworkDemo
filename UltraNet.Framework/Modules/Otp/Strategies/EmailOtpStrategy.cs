using UltraNet.Framework.Core.Interfaces.Otp;

namespace UltraNet.Framework.Modules.Otp.Strategies
{
    public class EmailOtpStrategy : IOTPStrategy
    {
        public string Key => "email";
        private readonly IMessageSenderService _sender;

        public EmailOtpStrategy(IMessageSenderService sender)
        {
            _sender = sender;
        }

        public Task SendAsync(string receiver, string code)
        {
            return _sender.SendAsync(receiver, $"Your Otp code: {code}");
        }
    }
}
