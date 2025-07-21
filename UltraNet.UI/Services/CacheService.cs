using System.Reflection;
using UltraNet.UI.Model;
using UltraNet.UI.Services;

public class CacheService : ICacheService
{
    private readonly HttpClient _http;

    public CacheService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("PublicClient");
    }

    public async Task<ReturnData<string>?> CacheData(CacheRequest model)
    {
        var response = await _http.PostAsJsonAsync("api/cache/GetFromCache", model);
 
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ReturnData<string>>();
        return result;
    }
}