using UltraNet.Framework.Core.Interfaces.RateLimiting;

namespace UltraNet.Framework.Modules.RateLimiting
{
    public class RateLimiter : IRateLimiter
    {
        private readonly IRateLimitStrategy _strategy;

        public RateLimiter(IRateLimitStrategy strategy)
        {
            _strategy = strategy;
        }

        public Task<bool> IsRequestAllowedAsync(string key)
        {
            return _strategy.IsAllowedAsync(key);
        }
    }
}
