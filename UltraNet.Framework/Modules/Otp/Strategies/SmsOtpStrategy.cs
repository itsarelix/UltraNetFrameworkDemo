using UltraNet.Framework.Core.Interfaces.Otp;

namespace UltraNet.Framework.Modules.Otp.Strategies
{
    public class SmsOtpStrategy : IOTPStrategy
    {
        public string Key => "sms";
        private readonly IMessageSenderService _sender;

        public SmsOtpStrategy(IMessageSenderService sender)
        {
            _sender = sender;
        }

        public Task SendAsync(string receiver, string code)
        {
            return _sender.SendAsync(receiver, $"Your Otp code: {code}");
        }
    }
}
