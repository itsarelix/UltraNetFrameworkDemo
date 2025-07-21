using System.Collections.Concurrent;
using UltraNet.Framework.Core.Interfaces.RateLimiting;

namespace UltraNet.Framework.Modules.RateLimiting.Strategies
{
    public class InMemoryTokenBucket : IRateLimitStrategy
    {
        private class Bucket
        {
            public int Tokens;
            public DateTime LastRefill;
        }

        private readonly ConcurrentDictionary<string, Bucket> _buckets = new();
        private readonly int _capacity;
        private readonly int _refillRatePerMinute;

        public InMemoryTokenBucket(int capacity = 3, int refillRatePerMinute = 10)
        {
            _capacity = capacity;
            _refillRatePerMinute = refillRatePerMinute;
        }

        public Task<bool> IsAllowedAsync(string key)
        {
            var bucket = _buckets.GetOrAdd(key, _ => new Bucket
            {
                Tokens = _capacity,
                LastRefill = DateTime.UtcNow
            });

            lock (bucket)
            {
                Refill(bucket);
                if (bucket.Tokens > 0)
                {
                    bucket.Tokens--;
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
        }

        private void Refill(Bucket bucket)
        {
            var now = DateTime.UtcNow;
            var elapsedMinutes = (now - bucket.LastRefill).TotalMinutes;

            if (elapsedMinutes > 1)
            {
                var refillAmount = (int)(elapsedMinutes * _refillRatePerMinute);
                bucket.Tokens = Math.Min(_capacity, bucket.Tokens + refillAmount);
                bucket.LastRefill = now;
            }
        }
    }
}
