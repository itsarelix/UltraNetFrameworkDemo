namespace UltraNet.Framework.Core.Constants
{
    public class OtpOptions
    {
        public List<string> Strategies { get; set; } = new();
        public int CodeLength { get; set; } = 6;
        public int ExpiryMinutes { get; set; } = 5;
    }
}

