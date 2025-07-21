using System.Reflection;
using UltraNet.UI.Model;
using UltraNet.UI.Services;

public class RateLimitService : IRateLimitService
{
    private readonly HttpClient _http;

    public RateLimitService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("PublicClient");
    }

    public async Task<ReturnData<string>?> CheckRateLimit(RateLimitRequest model)
    {
        var response = await _http.PostAsJsonAsync("api/RateLimit/CheckRateLimit", new { Key = model.Key});
 
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ReturnData<string>>();
        return result;

    }
}