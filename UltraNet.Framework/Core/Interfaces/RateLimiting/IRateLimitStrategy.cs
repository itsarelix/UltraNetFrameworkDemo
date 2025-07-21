namespace UltraNet.Framework.Core.Interfaces.RateLimiting;
    public interface IRateLimitStrategy
    {
        Task<bool> IsAllowedAsync(string key);
    }
