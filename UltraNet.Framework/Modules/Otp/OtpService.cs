using Microsoft.Extensions.Options;
using UltraNet.Framework.Core.Helpers;
using UltraNet.Framework.Core.Interfaces.Otp;
using UltraNet.Framework.Core.Constants;

namespace UltraNet.Framework.Modules.Otp
{
    public class OtpService : IOTPService
    {
        private readonly List<IOTPStrategy> _strategies;
        private readonly OtpOptions _options;
        private readonly ICacheService _cache;


        public OtpService(IEnumerable<IOTPStrategy> strategies, IOptions<OtpOptions> options, ICacheService cache)
        {
            _strategies = strategies.ToList();
            _options = options.Value;
            _cache = cache;
        }

        public async Task<string> GenerateAndSendOtpAsync(string receiver, int? length = null)
        {
            var code = OtpCodeGenerator.GenerateNumericCode(length ?? _options.CodeLength);

            var selected = _strategies
                .Where(s => _options.Strategies.Contains(s.Key, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (!selected.Any())
            {
                Console.WriteLine("Strategy not found!");
                return code;
            }

            foreach (var strategy in selected)
            {
                try
                {
                    await strategy.SendAsync(receiver, code);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {strategy.Key}: {ex.Message}");
                }
            }

            var cacheKey = $"otp:{receiver}";
            await _cache.SetAsync(cacheKey, code, TimeSpan.FromMinutes(_options.ExpiryMinutes));


            return code;
        }


        public async Task<bool> VerifyOtpAsync(string receiver, string inputCode)
        {
            var key = $"otp:{receiver}";

            var cachedCode = await _cache.GetAsync<string>(key);

            if (string.IsNullOrWhiteSpace(cachedCode))
                return false;

            if (cachedCode != inputCode)
                return false;

            await _cache.RemoveAsync(key);
            return true;
        }
    }
}
