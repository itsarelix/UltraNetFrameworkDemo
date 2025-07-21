namespace UltraNet.Framework.Core.Helpers;
    public static class OtpCodeGenerator
    {
        public static string GenerateNumericCode(int length = 6)
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10)));
        }
    }

